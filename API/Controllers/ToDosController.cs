// Imports
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

// File path
namespace API.Controllers;

// Api controller for the toDo entity paths
[ApiController]
[Route("api/[controller]")]
public class ToDosController(IToDoRepository repo) : ControllerBase
{
    // api/todos (GET)
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ToDo>>> GetToDos()
    {
        // Returns all the toDos found in the database
        return Ok(await repo.GetToDosAsync());
    }

    // api/todos/1 (GET)
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ToDo>> GetTodoById(int id)
    {
        // Finds the toDo that has the given id
        var toDo = await repo.GetToDoByIdAsync(id);

        // If it was not found, return
        if (toDo == null)
            return NotFound();

        // Else return the product
        return toDo;
    }

    // api/todos (POST)
    [HttpPost]
    public async Task<ActionResult<ToDo>> CreateToDo(ToDo toDo)
    {
        // Creates the toDo
        repo.AddToDo(toDo);

        // If toDo was created successfully, save the database
        if (await repo.SaveChangesAsync())
        {
            return CreatedAtAction("GetTodoById", new { id = toDo.Id }, toDo);
        }

        // Else, return
        return BadRequest("Error occured while creating toDo!");
    }

    // api/todos/1 (PUT)
    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateToDo(int id, ToDo toDo)
    {
        // Checks if the given id and the id of the toDo don't match, or if a toDo with the given id doesn't exists
        if (toDo.Id != id || !ToDoExists(id))
            return BadRequest("Error occured while updating toDo!");

        // Update the toDo
        repo.UpdateToDo(toDo);

        // If toDo was updated successfully, save the database
        if (await repo.SaveChangesAsync())
        {
            return NoContent();
        }

        // Else, return
        return BadRequest("Error occured while updating toDo!");
    }

    // api/todos/1 (DELETE)
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteToDo(int id)
    {
        // Finds the toDo that has the given id
        var toDo = await repo.GetToDoByIdAsync(id);

        // If it was not found, return
        if (toDo == null)
            return NotFound();

        // Delete the toDo
        repo.DeleteToDo(toDo);

        // If toDo was deleted successfully, save the database
        if (await repo.SaveChangesAsync())
        {
            return NoContent();
        }

        // Else, return
        return BadRequest("Error occured while deleting toDo!");
    }

    // Checks if a toDo with the given id exists
    private bool ToDoExists(int id)
    {
        return repo.ToDoExists(id);
    }
}
