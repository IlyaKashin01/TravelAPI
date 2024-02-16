using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using TravelApi.Common.Auth;
using TravelApi.Common.JsonConverter;
using TravelApi.Domain.Interfaces;
using TravelApi.Infrastructure.Business;
using TravelApi.Infrastructure.Data.Implementation;
using TravelApi.Services.Interfaces.Interfaces;

namespace TravelAPI
{
    public static class DI
    {
        public static IServiceCollection AddRepositoriesDI(this IServiceCollection services)
        {
            return services
                .AddScoped<ICarRepository, CarRepository>()
                .AddScoped<ICoordinatesRepository, CoordinatesRepository>()
                .AddScoped<IFriendRepository, FriendRepository>()
                .AddScoped<IJourneyRepository, JourneyRepository>()
                .AddScoped<IPersonRepository, PersonRepository>()
                .AddScoped<IServiceRepository, ServiceRepository>()
                .AddScoped<IPostRepository, PostRepository>()
                .AddScoped<IImageRepository, ImageRepository>()
                .AddScoped<IStorageRepository, StorageRepository>()
                .AddScoped<IPersonFIleRepository, PersonFileRepository>()
                .AddScoped<ISettingsRepository, SettingsRepository>();
        }

        public static IServiceCollection AddServicesDI(this IServiceCollection services)
        {
            return services
                .AddScoped<IAuthService, AuthService>()
                .AddScoped<ICarService, CarService>()
                .AddScoped<IFriendServise, FriendService>()
                .AddScoped<ICoordinatesService, CoordinatesService>()
                .AddScoped<IJourneyService, JourneyService>()
                .AddScoped<IPersonService, PersonService>()
                .AddScoped<IServicingService, ServicingService>()
                .AddScoped<IPostService, PostService>()
                .AddScoped<IParsingService, ParsingService>()
                .AddScoped<IStorageService, StorageService>()
                .AddScoped<ISettingsService, SettingsService>();
        }
        public static IServiceCollection AddCommonClassDI(this IServiceCollection services)
        {
            return services
                .AddScoped<IDecodingJWT, DecodingJWT>();
        }

        public static MvcOptions UseDateOnlyTimeOnlyStringConverters(this MvcOptions options)
        {
            TypeDescriptor.AddAttributes(typeof(DateOnly), new TypeConverterAttribute(typeof(DateOnlyJsonConverter)));
            TypeDescriptor.AddAttributes(typeof(TimeOnly), new TypeConverterAttribute(typeof(DateOnlyJsonConverter)));
            return options;
        }
    }
}
