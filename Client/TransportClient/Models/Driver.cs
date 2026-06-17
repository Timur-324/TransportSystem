namespace TransportClient.Models;

public class Driver
{
    public int Id { get; set; }
    public required string FullName { get; set; }
    public int ExperienceYears { get; set; }
    public required string LicenseNumber { get; set; }
}