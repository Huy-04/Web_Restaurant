using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using InventoryEntity = Inventory.Domain.Entities.Inventory;

namespace Inventory.Infrastructure.Persitence.EntityConfigurations
{
    public sealed class InventoryConfiguration : IEntityTypeConfiguration<InventoryEntity>
    {
        public void Configure(EntityTypeBuilder<InventoryEntity> entity)
        {
            entity.ToTable("Inventory");

            entity.HasKey(i => i.Id);
            entity.Property(i => i.Id).HasColumnName("IdInventory");

            entity.Property(i => i.IngredientsId)
                .IsRequired();
            entity.HasIndex(i => i.IngredientsId);

            entity.Property(i => i.Capacity)
                .HasConversion(InventoryConverters.CapacityConverter)
                .IsRequired();

            entity.Property(i => i.Quantity)
                .HasConversion(InventoryConverters.QuantityConverter)
                .IsRequired();

            entity.Property(i => i.InventoryStatus)
                .HasConversion(InventoryConverters.InventoryStatusConverter)
                .IsRequired();

            entity.Property(i => i.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAdd();

            entity.Property(i => i.UpdatedAt)
                .IsRequired();
        }
    }
}