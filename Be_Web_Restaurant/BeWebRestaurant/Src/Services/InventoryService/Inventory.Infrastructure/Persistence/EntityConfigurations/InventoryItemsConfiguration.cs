using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using InventoryEntity = Inventory.Domain.Entities.InventoryItems;

namespace Inventory.Infrastructure.Persitence.EntityConfigurations
{
    public sealed class InventoryItemsConfiguration : IEntityTypeConfiguration<InventoryEntity>
    {
        public void Configure(EntityTypeBuilder<InventoryEntity> entity)
        {
            entity.ToTable("InventoryItems");

            entity.HasKey(i => i.Id);
            entity.Property(i => i.Id).HasColumnName("IdInventoryItems");

            entity.Property(i => i.IngredientsId)
                .IsRequired();
            entity.HasIndex(i => i.IngredientsId);

            entity.Property(i => i.InventoryId)
                .IsRequired();
            entity.HasIndex(i => i.InventoryId);

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