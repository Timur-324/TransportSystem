namespace TransportServer.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public int ExperienceYears { get; set; }
        public required string LicenseNumber { get; set; }
        public ICollection<Transport>? Transports { get; set; } = new List<Transport>();
    }
}