// File path
namespace Core.Entities;

// ToDo entity class
public class ToDo
{
    // Id
    public int Id { get; set; }

    // Properties
    public required string Title { get; set; }
    public required string Description { get; set; }

    // Foreign properties
    public int AdventureId { get; set; }
}
