using Microsoft.EntityFrameworkCore;
using TravelApi.Domain.Core.Entities;
using TravelApi.Infrastructure.Data.Extensions;

namespace TravelApi.Infrastructure.Data
{
#nullable disable
    public class AppDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Coordinates> Coordinates { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Journey> Journeys { get; set; }
        public DbSet<JourneyJoinToPerson> JourneyJoinToPeople { get; set; }
        public DbSet<Person> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<PersonFile> PersonFiles { get; set; }
        public DbSet<Storage> Storage { get; set; }
        public DbSet<TaskJourney> Tasks { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<SettingsJoinToPerson> SettingsJoinToUsers { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<EventsJourney> EventsJourney { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<GroupChatRoom> Groups { get; set; }
        public DbSet<PersonJoinToGroup> PersonJoinToGroups { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddModelConfiguration();
            modelBuilder.AddDeletedQueryFilters();

            /*modelBuilder.Entity<Storage>().HasData(new Storage[]
           {
                new Storage{ Id = 1, },
                new Storage{ Id = 2, },
           });

            modelBuilder.Entity<Person>().HasData(new Person[]
            {
                new Person
                {
                    Id= 1,
                    Login = "Ilya",
                    FirstName = "Kashin",
                    LastName = "Ilya",
                    MiddleName = "Sergeevich",
                    Email = "sergeich33rus2001@gmail.com",
                    Phone = "",
                    PasswordHash = "$2a$11$HYX54sBn5zUJnOaiJA/HOe4SRUrnpxtYfbUBgmEBjMq0VDuUCSsZO",
                    Role = "user",
                    CreatedDate= DateTime.UtcNow,
                    StorageId = 1,

                },
                new Person
                {
                    Id= 2,
                    Login = "Liza",
                    FirstName = "Камбалова",
                    LastName = "Елизавета",
                    MiddleName = "",
                    Email = "",
                    Phone = "",
                    PasswordHash = "$2a$11$rgjE/KJ0aNgNQRfTn1.i4eMfCHXx8J834FHxSed/rP08LHxjQ.ar6",
                    Role = "user",
                    CreatedDate= DateTime.UtcNow,
                    StorageId = 2,

                }
            });
            modelBuilder.Entity<Friend>().HasData(new Friend[]
            {

                new Friend() { Id = 1, PersonOne = 1, PersonTwo = 2, PersonId = 1, CreatedDate = DateTime.UtcNow,},
            });

            modelBuilder.Entity<Journey>().HasData(new Journey[]
            {
                new Journey {Id = 1, Name = "Крым", Description = "Поездка в Крым", DateStart = new DateOnly(2023, 10, 1), DateEnd= new DateOnly(2023, 11, 1), CreatedDate = DateTime.UtcNow, CategoryId = 1},
                new Journey {Id = 2, Name = "Турция", Description = "Поездка в Турцию", DateStart = new DateOnly(2023, 9, 1), DateEnd= new DateOnly(2023, 10, 1), CreatedDate = DateTime.UtcNow,  CategoryId = 1},
            });

            modelBuilder.Entity<JourneyJoinToPerson>().HasData(new JourneyJoinToPerson[]
            {
                new JourneyJoinToPerson{Id = 1, CreatedDate = DateTime.UtcNow, JourneyId = 1, PersonId = 1},
                new JourneyJoinToPerson{Id = 2, CreatedDate = DateTime.UtcNow, JourneyId = 2, PersonId = 2},
            });*/
        }
    }
}
