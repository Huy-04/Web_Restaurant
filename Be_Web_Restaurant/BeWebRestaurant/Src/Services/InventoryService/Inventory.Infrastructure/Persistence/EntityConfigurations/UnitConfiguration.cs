using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.Persitence.EntityConfigurations
{
    public sealed class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> entity)
        {
            entity.ToTable("Unit");

            entity.HasKey(u => u.Id);
            entity.Property(u => u.Id).HasColumnName("IdUnit");

            entity.Property(u => u.UnitName)
                .HasConversion(InventoryConverters.UnitNameConverter)
                .HasMaxLength(50)
                .IsRequired();
            entity.HasIndex(u => u.UnitName).IsUnique();

            entity.Property(u => u.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAdd();

            entity.Property(u => u.UpdatedAt)
                .IsRequired();
        }
    }
}