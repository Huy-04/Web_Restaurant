using Inventory.Application.Interfaces;
using Inventory.Domain.Entities;
using Inventory.Infrastructure.Persitence;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly InventoryDbContext _context;

        public async Task<IEnumerable<Stock>> GetAllAsync()
        {
            return await _context.Stocks
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<Stock?> GetByIdAsync(Guid idStock)
        {
            return await _context.Stocks
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == idStock)
                .ConfigureAwait(false);
        }

        public async Task<Stock> CreateAsync(Stock stock)
        {
            await _context.Stocks.AddAsync(stock).ConfigureAwait(false);
            return stock;
        }

        public Task<Stock> UpdateAsync(Stock stock)
        {
            var entity = _context.Stocks.Update(stock);
            return Task.FromResult(stock);
        }

        public async Task<bool> DeleteAsync(Guid idStock)
        {
            return await _context.Stocks
                .AsNoTracking()
                .AnyAsync(s => s.Id == idStock)
                .ConfigureAwait(false);
        }
    }
}