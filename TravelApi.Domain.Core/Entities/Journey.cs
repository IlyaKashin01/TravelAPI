namespace TravelApi.Domain.Core.Entities
{
    public class Journey: BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal ExpectedCost { get; set; } 
        public decimal ActualCost { get; set; } 
        public decimal ProjectedCost { get; set; } 
        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }
        public int CountDays { get; set; } = 0;
        public int CountPerson { get; set; } = 0;
        public int CategoryId { get; set; } 
        public List<Coordinates> Coordinates { get; set; } = new List<Coordinates>();
        public List<Service> Services { get; set; } = new List<Service>();
        public List<JourneyJoinToPerson> Users { get; set; } = new List<JourneyJoinToPerson>();
        public List<TaskJourney> Tasks { get; set; } = new List<TaskJourney>();
        public List<EventsJourney> Events { get; set; } = new List<EventsJourney>();
    }
}
