using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using TravelApi.Domain.Core.Entities;
using TravelApi.Infrastructure.Data.ModelConfig;

namespace TravelApi.Infrastructure.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder AddModelConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StorageConfig());
            modelBuilder.ApplyConfiguration(new CarConfig());
            modelBuilder.ApplyConfiguration(new ChatMessageConfig());
            modelBuilder.ApplyConfiguration(new CoordinatesConfig());
            modelBuilder.ApplyConfiguration(new EventsJourneyConfig());
            modelBuilder.ApplyConfiguration(new GroupChatRoomConfig());
            modelBuilder.ApplyConfiguration(new ImageConfig());
            modelBuilder.ApplyConfiguration(new JourneyConfig());
            
            modelBuilder.ApplyConfiguration(new MessageJoinToGroupConfig());
            modelBuilder.ApplyConfiguration(new NotificationConfig());
            modelBuilder.ApplyConfiguration(new PersonConfig());
            modelBuilder.ApplyConfiguration(new FriendConfig());
            modelBuilder.ApplyConfiguration(new JourneyJoinToPersonConfig());
            modelBuilder.ApplyConfiguration(new PersonJoinToGroupConfig());
            modelBuilder.ApplyConfiguration(new PostConfig());
            modelBuilder.ApplyConfiguration(new RouteConfig());
            modelBuilder.ApplyConfiguration(new ServiceConfig());
            
            modelBuilder.ApplyConfiguration(new SettingsConfig());
            modelBuilder.ApplyConfiguration(new PersonFileConfig());
            modelBuilder.ApplyConfiguration(new TaskJourneyConfig());

            return modelBuilder;
        }

        public static ModelBuilder AddDeletedQueryFilters(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasQueryFilter(e => e.DeleteDate == null);
            modelBuilder.Entity<ChatMessage>().HasQueryFilter(e => e.DeleteDate == null);
            modelBuilder.Entity<Coordinates>().HasQueryFilter(e => e.DeleteDate == null);
            modelBuilder.Entity<EventsJourney>().HasQueryFilter(e => e.DeleteDate == null);
            modelBuilder.Entity<Friend>().HasQueryFilter(e => e.DeleteDate == null);
            modelBuilder.Entity<GroupChatRoom>().HasQueryFilter(e => e.DeleteDate == null);
            modelBuilder.Entity<Image>().HasQueryFilter(e => e.DeleteDate == null);
            modelBuilder.Entity<Journey>().HasQueryFilter(e => e.DeleteDate == null);
            modelBuilder.Entity<JourneyJoinToPerson>().HasQueryFilter(e => e.DeleteDate == null);
            modelBuilder.Entity<MessageJoinToGroup>().HasQueryFilter(e => e.DeleteDate == null);
            modelBuilder.Entity<Notification>().HasQueryFilter(e => e.DeleteDate == null);
            modelBuilder.Entity<Person>().HasQueryFilter(e => e.DeleteDate == null);
            modelBuilder.Entity<PersonJoinToGroup>().HasQueryFilter(e => e.DeleteDate == null);
            modelBuilder.Entity<Post>().HasQueryFilter(e => e.DeleteDate == null);
            modelBuilder.Entity<Route>().HasQueryFilter(e => e.DeleteDate == null);
            modelBuilder.Entity<Service>().HasQueryFilter(e => e.DeleteDate == null);
            modelBuilder.Entity<Settings>().HasQueryFilter(e => e.DeleteDate == null);
            modelBuilder.Entity<Storage>().HasQueryFilter(e => e.DeleteDate == null);
            modelBuilder.Entity<TaskJourney>().HasQueryFilter(e => e.DeleteDate == null);

            return modelBuilder;
        }
    }
}
