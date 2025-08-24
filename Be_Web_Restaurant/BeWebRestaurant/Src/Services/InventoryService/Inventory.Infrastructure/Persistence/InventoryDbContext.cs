using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using InventoryEntity = Inventory.Domain.Entities.Inventory;

namespace Inventory.Infrastructure.Persitence
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {
        }

        public DbSet<FoodRecipe> FoodRecipes => Set<FoodRecipe>();
        public DbSet<InventoryEntity> Inventories => Set<InventoryEntity>();
        public DbSet<Ingredients> Ingredients => Set<Ingredients>();
        public DbSet<StockReceipt> StockReceipts => Set<StockReceipt>();
        public DbSet<Unit> Units => Set<Unit>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly(),
                t => t.Namespace!.Contains(".EntityConfigurations"));
        }
    }
}