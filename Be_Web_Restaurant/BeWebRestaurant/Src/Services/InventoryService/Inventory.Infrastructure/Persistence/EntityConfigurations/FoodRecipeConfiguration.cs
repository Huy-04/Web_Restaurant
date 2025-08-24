using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.Persitence.EntityConfigurations
{
    public sealed class FoodRecipeConfiguration : IEntityTypeConfiguration<FoodRecipe>
    {
        public void Configure(EntityTypeBuilder<FoodRecipe> entity)
        {
            entity.ToTable("FoodRecipe");

            entity.HasKey(f => f.Id);
            entity.Property(f => f.Id).HasColumnName("IdFoodRecipe");

            entity.Property(f => f.FoodId)
                .IsRequired();
            entity.HasIndex(f => f.FoodId);

            entity.Property(f => f.IngredientsId)
                .IsRequired();
            entity.HasIndex(f => f.IngredientsId);

            entity.Property(f => f.Quantity)
                .HasConversion(InventoryConverters.QuantityConverter)
                .IsRequired();

            entity.Property(f => f.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAdd();

            entity.Property(f => f.UpdatedAt)
                .IsRequired();
        }
    }
}