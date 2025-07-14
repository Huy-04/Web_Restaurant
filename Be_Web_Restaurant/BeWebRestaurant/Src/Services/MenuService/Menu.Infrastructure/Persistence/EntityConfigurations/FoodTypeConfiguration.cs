using Menu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Infrastructure.Persistence.EntityConfigurations
{
    public class FoodTypeConfiguration : IEntityTypeConfiguration<FoodType>
    {
        public void Configure(EntityTypeBuilder<FoodType> b)
        {
            b.ToTable("FoodType");

            b.HasKey(ft => ft.Id);
            b.Property(ft => ft.Id).HasColumnName("IdFoodType");

            b.Property(ft => ft.FoodTypeName)
                .HasConversion(Converters.FoodTypeNameConverter)
                .HasColumnName("NameFoodType")
                .HasMaxLength(50)
                .IsRequired();

            b.HasIndex(ft => ft.FoodTypeName).IsUnique();

            b.Property(ft => ft.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAdd();

            b.Property(ft => ft.UpdatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}