namespace TransportClient.Models;

public class Transport
{
    public int Id { get; set; }
    public required string NumberPlate { get; set; }
    public required string Type { get; set; }
    public bool IsActive { get; set; }
}