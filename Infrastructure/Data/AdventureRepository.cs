// Imports
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

// File path
namespace Infrastructure.Data;

// Adventure entity database repository
public class AdventureRepository(StoreContext context) : IAdventureRepository
{
    // Adds an adventure to the database
    public void AddAdventure(Adventure adventure)
    {
        context.Adventures.Add(adventure);
    }

    // Checks if an adventure with the given id exists
    public bool AdventureExists(int id)
    {
        return context.Adventures.Any(adventure => adventure.Id == id);
    }

    // Deletes an adventure
    public void DeleteAdventure(Adventure adventure)
    {
        context.Adventures.Remove(adventure);
    }

    // Gets the adventure that has the given id
    public async Task<Adventure?> GetAdventureByIdAsync(int id)
    {
        return await context.Adventures.FindAsync(id);
    }

    // Gets all the adventures from the database
    public async Task<IReadOnlyList<Adventure>> GetAdventuresAsync()
    {
        return await context.Adventures.ToListAsync();
    }

    // Saves the changes done to the database
    public async Task<bool> SaveChangesAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }

    // Updates an adventure
    public void UpdateAdventure(Adventure adventure)
    {
        context.Entry(adventure).State = EntityState.Modified;
    }
}
