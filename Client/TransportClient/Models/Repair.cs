namespace TransportClient.Models;

public class Repair
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Cost { get; set; }
    public required string Description { get; set; }
    public int TransportId { get; set; }
}