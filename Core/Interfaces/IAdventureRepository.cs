// Imports
using Core.Entities;

// File path
namespace Core.Interfaces;

// Adventure entity database repository interface
public interface IAdventureRepository
{
    // Gets all the adventures from the database
    Task<IReadOnlyList<Adventure>> GetAdventuresAsync();

    // Gets the adventure that has the given id
    Task<Adventure?> GetAdventureByIdAsync(int id);

    // Adds an adventure to the database
    void AddAdventure(Adventure adventure);

    // Updates an adventure
    void UpdateAdventure(Adventure adventure);

    // Deletes an adventure
    void DeleteAdventure(Adventure adventure);

    // Checks if an adventure with the given id exists
    bool AdventureExists(int id);

    // Saves the changes done to the database
    Task<bool> SaveChangesAsync();
}
