// Imports
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

// File path
namespace API.Controllers;

// Api controller for the adventure entity paths
[ApiController]
[Route("api/[controller]")]
public class AdventuresController(IAdventureRepository repo) : ControllerBase
{
    // api/adventures (GET)
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Adventure>>> GetAdventures()
    {
        // Returns all the adventures found in the database
        return Ok(await repo.GetAdventuresAsync());
    }

    // api/adventures/1 (GET)
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Adventure>> GetAdventureById(int id)
    {
        // Finds the adventure that has the given id
        var adventure = await repo.GetAdventureByIdAsync(id);

        // If it was not found, return
        if (adventure == null)
            return NotFound();

        // Else return the product
        return adventure;
    }

    // api/adventures (POST)
    [HttpPost]
    public async Task<ActionResult<Adventure>> CreateAdventure(Adventure adventure)
    {
        // Creates the adventure
        repo.AddAdventure(adventure);

        // If adventure was created successfully, save the database
        if (await repo.SaveChangesAsync())
        {
            return CreatedAtAction("GetAdventureById", new { id = adventure.Id }, adventure);
        }

        // Else, return
        return BadRequest("Error occured while creating adventure!");
    }

    // api/adventures/1 (PUT)
    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateAdventure(int id, Adventure adventure)
    {
        // Checks if the given id and the id of the adventure don't match, or if an adventure with the given id doesn't exists
        if (adventure.Id != id || !AdventureExists(id))
            return BadRequest("Error occured while updating adventure!");

        // Update the adventure
        repo.UpdateAdventure(adventure);

        // If adventure was updated successfully, save the database
        if (await repo.SaveChangesAsync())
        {
            return NoContent();
        }

        // Else, return
        return BadRequest("Error occured while updating adventure!");
    }

    // api/adventures/1 (DELETE)
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        // Finds the adventure that has the given id
        var adventure = await repo.GetAdventureByIdAsync(id);

        // If it was not found, return
        if (adventure == null)
            return NotFound();

        // Delete the adventure
        repo.DeleteAdventure(adventure);

        // If adventure was deleted successfully, save the database
        if (await repo.SaveChangesAsync())
        {
            return NoContent();
        }

        // Else, return
        return BadRequest("Error occured while deleting adventure!");
    }

    // Checks if an adventure with the given id exists
    private bool AdventureExists(int id)
    {
        return repo.AdventureExists(id);
    }
}
