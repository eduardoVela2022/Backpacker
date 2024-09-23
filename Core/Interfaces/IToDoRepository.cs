// Imports
using Core.Entities;

// File path
namespace Core.Interfaces;

// ToDo entity database repository interface
public interface IToDoRepository
{
    // Gets all the toDos from the database
    Task<IReadOnlyList<ToDo>> GetToDosAsync();

    // Gets the toDo that has the given id
    Task<ToDo?> GetToDoByIdAsync(int id);

    // Adds a toDo to the database
    void AddToDo(ToDo toDo);

    // Updates a toDo
    void UpdateToDo(ToDo toDo);

    // Deletes a toDo
    void DeleteToDo(ToDo toDo);

    // Checks if an toDo with the given id exists
    bool ToDoExists(int id);

    // Saves the changes done to the database
    Task<bool> SaveChangesAsync();
}
