using APBD_ex6.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_ex6.Configurations;

public class ComponentTypeConfiguration : IEntityTypeConfiguration<ComponentType>
{
    public void Configure(EntityTypeBuilder<ComponentType> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Abbreviation).IsRequired().HasMaxLength(30);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(150);

        builder.ToTable("ComponentTypes");

        builder.HasData(new List<ComponentType>
        {
            new() { Id = 1, Abbreviation = "CPU", Name = "Processor" },
            new() { Id = 2, Abbreviation = "GPU", Name = "Graphics Card" },
            new() { Id = 3, Abbreviation = "RAM", Name = "Memory" }
        });
    }
}