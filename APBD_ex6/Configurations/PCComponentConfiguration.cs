using APBD_ex6.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_ex6.Configurations;

public class PCComponentConfiguration : IEntityTypeConfiguration<PCComponent>
{
    public void Configure(EntityTypeBuilder<PCComponent> builder)
    {
        builder.HasKey(x => new { x.PCId, x.ComponentCode });

        builder.Property(x => x.ComponentCode).HasColumnType("char(10)");
        builder.Property(x => x.Amount).IsRequired();
        
        builder.HasOne(x => x.PC)
            .WithMany(p => p.PCComponents)
            .HasForeignKey(x => x.PCId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(x => x.Component)
            .WithMany(c => c.PCComponents)
            .HasForeignKey(x => x.ComponentCode)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable("PCComponents");

        builder.HasData(new List<PCComponent>
        {
            new() { PCId = 1, ComponentCode = "CPU0000001", Amount = 1 },
            new() { PCId = 1, ComponentCode = "GPU0000001", Amount = 1 },
            new() { PCId = 1, ComponentCode = "RAM0000001", Amount = 2 },
            new() { PCId = 2, ComponentCode = "CPU0000001", Amount = 1 },
            new() { PCId = 3, ComponentCode = "GPU0000001", Amount = 1 }
        });
    }
}