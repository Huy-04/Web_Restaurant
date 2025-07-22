using Menu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Menu.Infrastructure.Persistence.EntityConfigurations
{
    public sealed class FoodConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> b)
        {
            b.ToTable("Food");

            b.HasKey(f => f.Id);
            b.Property(f => f.Id).HasColumnName("IdFood");

            b.Property(f => f.FoodName)
                .HasConversion(Converters.FoodNameConverter)
                .HasColumnName("NameFood")
                .HasMaxLength(50)
                .IsRequired();

            b.Property(f => f.Img)
                .HasConversion(Converters.ImgConverter)
                .HasColumnName("Img")
                .HasMaxLength(255)
                .IsRequired();

            b.Property(f => f.Description)
                .HasConversion(Converters.DescriptionConverter)
                .HasColumnName("Description")
                .HasMaxLength(255)
                .IsRequired();

            b.Property(f => f.FoodStatus)
                .HasConversion(Converters.FoodStatusConverter)
                .HasColumnName("Status")
                .IsRequired();

            b.Property(f => f.Prices)
                .HasConversion(Converters.PriceListConverter)
                .HasColumnName("Prices")
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            b.Property(f => f.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAdd();

            b.Property(f => f.UpdatedAt)
                .IsRequired();

            b.Property(f => f.FoodTypeId)
                .IsRequired();
            b.HasIndex(f => f.FoodTypeId);
        }
    }
}