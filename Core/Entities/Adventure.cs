// File path
namespace Core.Entities;

// Adventure entity class
public class Adventure
{
    // Id
    public int Id { get; set; }

    // Properties
    public required string Destination { get; set; }
    public DateTime DepartureDate { get; set; }
    public DateTime ArrivalDate { get; set; }

    // Foreign properties
    public List<ToDo> ToDos { get; set; } = [];
}
