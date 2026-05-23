using APBD_ex6.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_ex6.Configurations;

public class ComponentManufacturerConfiguration : IEntityTypeConfiguration<ComponentManufacturer>
{
    public void Configure(EntityTypeBuilder<ComponentManufacturer> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Abbreviation).IsRequired().HasMaxLength(30);
        builder.Property(x => x.FullName).IsRequired().HasMaxLength(300);
        builder.Property(x => x.FoundationDate).HasColumnType("date");

        builder.ToTable("ComponentManufacturers");

        builder.HasData(new List<ComponentManufacturer>
        {
            new() { Id = 1, Abbreviation = "AMD", FullName = "Advanced Micro Devices", FoundationDate = DateOnly.Parse("1980-01-01") },
            new() { Id = 2, Abbreviation = "NV", FullName = "NVIDIA Corporation", FoundationDate = DateOnly.Parse("1981-01-01") },
            new() { Id = 3, Abbreviation = "COR", FullName = "Corsair Gaming Inc.", FoundationDate = DateOnly.Parse("1982-01-01") }
        });
    }
}