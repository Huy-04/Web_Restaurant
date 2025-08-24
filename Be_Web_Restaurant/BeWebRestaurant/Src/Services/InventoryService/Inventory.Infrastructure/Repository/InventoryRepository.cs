using Inventory.Application.Interfaces;
using Inventory.Domain.ValueObjects.Inventory;
using Inventory.Infrastructure.Persitence;
using Microsoft.EntityFrameworkCore;
using InventoryEntity = Inventory.Domain.Entities.Inventory;

namespace Inventory.Infrastructure.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly InventoryDbContext _context;

        public InventoryRepository(InventoryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InventoryEntity>> GetAllAsync()
        {
            return await _context.Inventories
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<InventoryEntity?> GetByIdAsync(Guid idInventory)
        {
            return await _context.Inventories
                .AsNoTracking()
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<InventoryEntity>> GetByIngredientsAsync(Guid ingredientsId)
        {
            return await _context.Inventories
                .AsNoTracking()
                .Where(i => i.IngredientsId == ingredientsId)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<InventoryEntity>> GetByStatusAsync(InventoryStatus inventoryStatus)
        {
            return await _context.Inventories
                .AsNoTracking()
                .Where(i => i.InventoryStatus == inventoryStatus)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<InventoryEntity> CreateAsync(InventoryEntity inventory)
        {
            await _context.Inventories.AddAsync(inventory).ConfigureAwait(false);
            return inventory;
        }

        public Task<InventoryEntity> UpdateAsync(InventoryEntity inventory)
        {
            var entity = _context.Update(inventory);
            return Task.FromResult(inventory);
        }

        public async Task<bool> DeleteAsync(Guid idInventory)
        {
            var entity = await _context.Inventories.FindAsync(idInventory);
            if (entity is null) return false;
            _context.Inventories.Remove(entity);
            return true;
        }
    }
}