using Common.PropertyConverters;
using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.Persitence.EntityConfigurations
{
    public sealed class StockReceiptConfiguration : IEntityTypeConfiguration<StockReceipt>
    {
        public void Configure(EntityTypeBuilder<StockReceipt> entity)
        {
            entity.ToTable("StockReceipt");

            entity.HasKey(s => s.Id);
            entity.Property(s => s.Id).HasColumnName("IdStockReceipt");

            entity.Property(s => s.IngredientsId)
                .IsRequired();
            entity.HasIndex(s => s.IngredientsId);

            entity.Property(s => s.Quantity)
                .HasConversion(InventoryConverters.QuantityConverter)
                .IsRequired();

            entity.Property(s => s.UnitId)
                .IsRequired();

            entity.Property(s => s.Prices)
                .HasConversion(CommonConverters.PriceListConverter)
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            entity.Property(s => s.Supplier)
                .HasConversion(InventoryConverters.SupplierConverter)
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(s => s.Importdate)
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAdd();
        }
    }
}