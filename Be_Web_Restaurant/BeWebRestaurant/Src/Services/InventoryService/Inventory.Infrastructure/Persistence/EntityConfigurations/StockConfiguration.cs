using Common.PropertyConverters;
using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.Persistence.EntityConfigurations
{
    public sealed class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> entity)
        {
            entity.ToTable("Stock");

            entity.HasKey(s => s.Id);
            entity.Property(s => s.Id).HasColumnName("IdStock");

            entity.Property(s => s.Description)
                .HasConversion(CommonConverters.DescriptionConverter)
                .HasMaxLength(255)
                .IsRequired();

            entity.Property(s => s.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAdd();

            entity.Property(s => s.UpdatedAt)
                .IsRequired();
        }
    }
}