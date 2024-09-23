using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// [Services]
// Controller service
builder.Services.AddControllers();

// Database connection
builder.Services.AddDbContext<StoreContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Adventure repository
builder.Services.AddScoped<IAdventureRepository, AdventureRepository>();

// ToDo repository
builder.Services.AddScoped<IToDoRepository, ToDoRepository>();

// Builds the app
var app = builder.Build();

// [Middleware]
// Controller middleware
app.MapControllers();

// Database middleware
try
{
    // Creates a scoped service for the store context
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<StoreContext>();

    // Applies migrations to the database and creates the database if it doesn't exist.
    await context.Database.MigrateAsync();

    // Applies the database seeds to the database.
    await StoreContextSeed.SeedAsync(context);
}
catch (Exception ex)
{
    // If an error occurs print error into the console
    Console.WriteLine(ex);
    throw;
}

// Runs the app
app.Run();
