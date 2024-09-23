// Imports
using System;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

// File path
namespace Infrastructure.Data;

// ToDo entity database repository
public class ToDoRepository(StoreContext context) : IToDoRepository
{
    // Adds a toDo to the database
    public void AddToDo(ToDo toDo)
    {
        context.ToDos.Add(toDo);
    }

    // Deletes a toDo
    public void DeleteToDo(ToDo toDo)
    {
        context.ToDos.Remove(toDo);
    }

    // Gets the toDo that has the given id
    public async Task<ToDo?> GetToDoByIdAsync(int id)
    {
        return await context.ToDos.FindAsync(id);
    }

    // Gets all the toDos from the database
    public async Task<IReadOnlyList<ToDo>> GetToDosAsync()
    {
        return await context.ToDos.ToListAsync();
    }

    // Saves the changes done to the database
    public async Task<bool> SaveChangesAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }

    // Checks if an toDo with the given id exists
    public bool ToDoExists(int id)
    {
        return context.ToDos.Any(toDo => toDo.Id == id);
    }

    // Updates a toDo
    public void UpdateToDo(ToDo toDo)
    {
        context.Entry(toDo).State = EntityState.Modified;
    }
}
