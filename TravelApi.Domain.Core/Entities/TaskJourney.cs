namespace TravelApi.Domain.Core.Entities
{
    public class TaskJourney: BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty;
        public Journey Journey { get; set; } = new Journey();
        public int JourneyId { get; set; }
    }
}
