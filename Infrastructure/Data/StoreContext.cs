// Imports
using Core.Entities;
using Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

// File path
namespace Infrastructure.Data;

// Database store context
public class StoreContext(DbContextOptions options) : DbContext(options)
{
    // Adventures table
    public DbSet<Adventure> Adventures { get; set; }

    // ToDos table
    public DbSet<ToDo> ToDos { get; set; }

    // Entity configurations
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Adventure entity
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AdventureConfiguration).Assembly);
        // ToDo entity
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ToDoConfiguration).Assembly);
    }
}
