using Inventory.Application.Interfaces;
using Inventory.Domain.Entities;
using Inventory.Infrastructure.Persitence;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure.Repository
{
    public class StockReceiptRepository : IStockReceiptRepository
    {
        private readonly InventoryDbContext _context;

        public StockReceiptRepository(InventoryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StockReceipt>> GetAllAsync()
        {
            return await _context.StockReceipts
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<StockReceipt?> GetByIdAsync(Guid idStockReceipt)
        {
            return await _context.StockReceipts
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == idStockReceipt)
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<StockReceipt>> GetByIngredientsAsync(Guid idngredientsId)
        {
            return await _context.StockReceipts
                .AsNoTracking()
                .Where(s => s.IngredientsId == idngredientsId)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<StockReceipt> CreateAsync(StockReceipt stockReceipt)
        {
            await _context.AddAsync(stockReceipt).ConfigureAwait(false);
            return stockReceipt;
        }

        public Task<StockReceipt> UpdateAsync(StockReceipt stockReceipt)
        {
            var entity = _context.Update(stockReceipt);
            return Task.FromResult(stockReceipt);
        }

        public async Task<bool> DeleteAsync(Guid idStockReceipt)
        {
            var entity = await _context.StockReceipts.FindAsync(idStockReceipt);
            if (entity is null) return false;
            _context.StockReceipts.Remove(entity);
            return true;
        }
    }
}