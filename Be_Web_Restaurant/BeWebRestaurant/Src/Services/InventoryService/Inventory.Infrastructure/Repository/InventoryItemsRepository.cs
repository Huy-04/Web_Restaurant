using Inventory.Application.Interfaces;
using Inventory.Domain.ValueObjects.StockItems;
using Inventory.Infrastructure.Persitence;
using Microsoft.EntityFrameworkCore;
using InventoryEntity = Inventory.Domain.Entities.StockItems;

namespace Inventory.Infrastructure.Repository
{
    public class InventoryItemsRepository : IStockItemsRepository
    {
        private readonly InventoryDbContext _context;

        public InventoryItemsRepository(InventoryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InventoryEntity>> GetAllAsync()
        {
            return await _context.InventoryItems
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<InventoryEntity?> GetByIdAsync(Guid idInventory)
        {
            return await _context.InventoryItems
                .AsNoTracking()
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<InventoryEntity>> GetByIngredientsAsync(Guid ingredientsId)
        {
            return await _context.InventoryItems
                .AsNoTracking()
                .Where(i => i.IngredientsId == ingredientsId)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<InventoryEntity>> GetByInventoryAsync(Guid inventoryId)
        {
            return await _context.InventoryItems
                .AsNoTracking()
                .Where(i => i.InventoryId == inventoryId)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<InventoryEntity>> GetByStatusAsync(StockItemsStatus inventoryStatus)
        {
            return await _context.InventoryItems
                .AsNoTracking()
                .Where(i => i.InventoryStatus == inventoryStatus)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<InventoryEntity> CreateAsync(InventoryEntity inventory)
        {
            await _context.InventoryItems.AddAsync(inventory).ConfigureAwait(false);
            return inventory;
        }

        public Task<InventoryEntity> UpdateAsync(InventoryEntity inventory)
        {
            var entity = _context.Update(inventory);
            return Task.FromResult(inventory);
        }

        public async Task<bool> DeleteAsync(Guid idInventory)
        {
            var entity = await _context.InventoryItems.FindAsync(idInventory);
            if (entity is null) return false;
            _context.InventoryItems.Remove(entity);
            return true;
        }
    }
}