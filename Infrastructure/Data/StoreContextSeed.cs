// Imports
using System.Text.Json;
using Core.Entities;

// File path
namespace Infrastructure.Data;

// Database seeds
public class StoreContextSeed
{
    // Seeds the database
    public static async Task SeedAsync(StoreContext context)
    {
        // Adventure entity seeds
        if (!context.Adventures.Any())
        {
            // Reads the seed data from the adventures.json file
            var adventureData = await File.ReadAllTextAsync(
                "../Infrastructure/Data/SeedData/adventures.json"
            );

            // Converts it from JSON to C#
            var adventures = JsonSerializer.Deserialize<List<Adventure>>(adventureData);

            // If no seed data was found, return
            if (adventures == null)
                return;

            // Adds the seed data to the database
            context.Adventures.AddRange(adventures);

            // Saves the database
            await context.SaveChangesAsync();
        }

        // ToDo entity seeds
        if (!context.ToDos.Any())
        {
            // Reads the seed data from the toDos.json file
            var toDoData = await File.ReadAllTextAsync(
                "../Infrastructure/Data/SeedData/toDos.json"
            );

            // Converts it from JSON to C#
            var toDos = JsonSerializer.Deserialize<List<ToDo>>(toDoData);

            // If no seed data was found, return
            if (toDos == null)
                return;

            // Adds the seed data to the database
            context.ToDos.AddRange(toDos);

            // Saves the database
            await context.SaveChangesAsync();
        }
    }
}
