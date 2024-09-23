// Imports
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

// File path
namespace Infrastructure.Config;

// Adventure entity configuration
public class AdventureConfiguration : IEntityTypeConfiguration<Adventure>
{
    public void Configure(EntityTypeBuilder<Adventure> builder)
    {
        // Destination max length
        builder.Property(adventure => adventure.Destination).HasMaxLength(150);
    }
}
