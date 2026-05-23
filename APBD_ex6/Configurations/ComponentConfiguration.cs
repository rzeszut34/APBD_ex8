using APBD_ex6.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_ex6.Configurations;

public class ComponentConfiguration : IEntityTypeConfiguration<Component>
{
    public void Configure(EntityTypeBuilder<Component> builder)
    {
        builder.HasKey(x => x.Code);
        builder.Property(x => x.Code).IsRequired().HasColumnType("char(10)");
        builder.Property(x => x.Name).IsRequired().HasMaxLength(300);
        builder.Property(x => x.Description).IsRequired().HasColumnType("nvarchar(max)");

        builder.HasOne(x => x.ComponentManufacturer)
            .WithMany(m => m.Components)
            .HasForeignKey(x => x.ComponentManufacturersId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ComponentType)
            .WithMany(t => t.Components)
            .HasForeignKey(x => x.ComponentTypesId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable("Components");

        builder.HasData(new List<Component>
        {
            new() { Code = "CPU0000001", Name = "Ryzen 7 7800X3D", Description = "8-core gaming processor", ComponentManufacturersId = 1, ComponentTypesId = 1 },
            new() { Code = "GPU0000001", Name = "RTX 4080 Super", Description = "High-end gaming graphics card", ComponentManufacturersId = 2, ComponentTypesId = 2 },
            new() { Code = "RAM0000001", Name = "Corsair Vengeance DDR5 16GB", Description = "DDR5 RAM module 16GB", ComponentManufacturersId = 3, ComponentTypesId = 3 }
        });
    }
}