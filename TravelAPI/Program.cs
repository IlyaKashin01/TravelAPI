using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json;
using TravelApi.Common.Auth;
using TravelApi.Common.Chat;
using TravelApi.Common.Email;
using TravelApi.Common.OperationResult;
using TravelApi.Infrastructure.Data;
using TravelAPI;
using SwaggerGen.SignalR;
using SwaggerGen.SignalR.Attributes;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSignalR(e => {
    e.MaximumReceiveMessageSize = 102400000;
    e.HandshakeTimeout = TimeSpan.FromMinutes(1);
    e.ClientTimeoutInterval = TimeSpan.FromMinutes(5);
    e.KeepAliveInterval = TimeSpan.FromMinutes(5);
    e.StreamBufferCapacity = 20;
    e.MaximumParallelInvocationsPerClient = 10;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = Assembly.GetExecutingAssembly().GetName().Name,
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "bearer",
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme
            {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
            },
            new string[] { }
        }
    });

    c.UseDateOnlyTimeOnlyStringConverters();
    //c.SwaggerSignalR();
});

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(
    builder.Configuration.GetConnectionString("TravelPlanner")));

builder.Services.Configure<AuthOptions>(configuration.GetSection("Auth"));
builder.Services.Configure<EmailOptions>(configuration.GetSection("Email"));


builder.Services.AddRepositoriesDI();
builder.Services.AddServicesDI();
builder.Services.AddCommonClassDI();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddCors(options => options.AddDefaultPolicy(build =>
    build.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod() ) ); 

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errorMessages = context.ModelState.Values.Select(x => x.Errors.Select(y => y.ErrorMessage).ToList()).ToList();
        var commandResult = OperationResult.Fail(OperationCode.ValidationError, JsonSerializer.Serialize(errorMessages));
        var result = new BadRequestObjectResult(commandResult);
        return result;
    };
});
var authOptions = configuration.GetSection("Auth").Get<AuthOptions>();
var emailOptions = configuration.GetSection("Email").Get<EmailOptions>();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = authOptions.Issuer,
            ValidAudience =  authOptions.Audience,
            IssuerSigningKey = authOptions.GetSymmetricSecurityKey()
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
 .AllowAnyOrigin()
 .AllowAnyHeader()
.AllowAnyMethod());

//app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHub<ChatHub>("/chatHub");

app.Run();
