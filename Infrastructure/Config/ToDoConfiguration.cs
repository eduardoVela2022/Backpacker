// Imports
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

// File path
namespace Infrastructure.Config;

// ToDo entity configuration
public class ToDoConfiguration : IEntityTypeConfiguration<ToDo>
{
    public void Configure(EntityTypeBuilder<ToDo> builder)
    {
        // Title max length
        builder.Property(toDo => toDo.Title).HasMaxLength(150);
        // Description max langth
        builder.Property(toDo => toDo.Description).HasMaxLength(600);
    }
}
