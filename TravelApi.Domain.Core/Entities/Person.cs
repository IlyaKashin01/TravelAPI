namespace TravelApi.Domain.Core.Entities
{
    public class Person : BaseEntity
    {
        public string Login { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public DateTime Verified { get; set; }
        public bool IsVerified { get; set; }
        public DateTime PasswordReset { get; set; }
        public string ConnectionId { get; set; } = string.Empty;
        public Byte[]? Avatar { get; set; }
        public List<Car> Cars { get; set; } = new List<Car>();
        public List<JourneyJoinToPerson> Journeys { get; set; } = new List<JourneyJoinToPerson>();
        public List<Friend> Friends { get; set; } = new List<Friend>();
        public List<Coordinates> Coordinates { get; set; } = new List<Coordinates>();
        public List<Post> Posts { get; set; } = new List<Post>();
        public Storage Storage { get; set; } = new Storage();
        public int StorageId { get; set; }
        public List<SettingsJoinToPerson> Settings { get; set; } = new List<SettingsJoinToPerson>();
        public List<PersonJoinToGroup> Groups { get; set; } = new List<PersonJoinToGroup>();
        public List<Notification> Notifications { get; set; } = new List<Notification>();
    }
}
