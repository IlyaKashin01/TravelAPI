namespace TravelApi.Domain.Core.Entities
{
    public class Route: BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public List<Coordinates> Coordinates = new List<Coordinates>();
    }
}
