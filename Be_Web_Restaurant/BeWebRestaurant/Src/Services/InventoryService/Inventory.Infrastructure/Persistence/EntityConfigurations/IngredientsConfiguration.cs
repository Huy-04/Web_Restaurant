using Common.PropertyConverters;
using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.Persitence.EntityConfigurations
{
    public sealed class IngredientsConfiguration : IEntityTypeConfiguration<Ingredients>
    {
        public void Configure(EntityTypeBuilder<Ingredients> entity)
        {
            entity.ToTable("Ingredients");

            entity.HasKey(i => i.Id);
            entity.Property(i => i.Id).HasColumnName("IdIngredients");

            entity.Property(i => i.IngredientsName)
                .HasConversion(InventoryConverters.IngredientsNameConverter)
                .HasMaxLength(50)
                .IsRequired();
            entity.HasIndex(i => i.IngredientsName).IsUnique();

            entity.Property(i => i.UnitId)
                .IsRequired();

            entity.Property(i => i.Description)
                .HasConversion(CommonConverters.DescriptionConverter)
                .HasMaxLength(255)
                .IsRequired();

            entity.Property(i => i.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAdd();

            entity.Property(i => i.UpdatedAt)
                .IsRequired();
        }
    }
}