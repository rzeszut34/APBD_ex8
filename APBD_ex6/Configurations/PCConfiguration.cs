using APBD_ex6.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_ex6.Configurations;

public class PCConfiguration : IEntityTypeConfiguration<PC>
{
    public void Configure(EntityTypeBuilder<PC> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Weight).HasColumnType("float");
        builder.Property(x => x.Warranty).IsRequired();
        builder.Property(x => x.CreatedAt).HasColumnType("datetime");
        builder.Property(x => x.Stock).IsRequired();

        builder.ToTable("PCs");

        builder.HasData(new List<PC>
        {
            new() { Id = 1, Name = "Gaming Beast X", Weight = 12.5f, Warranty = 36, CreatedAt = DateTime.Parse("2026-05-08T09:00:00"), Stock = 5 },
            new() { Id = 2, Name = "Office Mini Pro", Weight = 4.2f, Warranty = 24, CreatedAt = DateTime.Parse("2026-04-15T13:30:00"), Stock = 12 },
            new() { Id = 3, Name = "Silent Dev Station", Weight = 8.5f, Warranty = 24, CreatedAt = DateTime.Parse("2026-05-20T10:00:00"), Stock = 3 }
        });
    }
}