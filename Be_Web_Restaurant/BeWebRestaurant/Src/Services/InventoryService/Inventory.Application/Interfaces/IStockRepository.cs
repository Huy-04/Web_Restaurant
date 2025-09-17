using Inventory.Domain.Entities;

namespace Inventory.Application.Interfaces
{
    public interface IStockRepository
    {
        public Task<IEnumerable<Stock>> GetAllAsync();

        public Task<Stock?> GetByIdAsync(Guid idStock);

        public Task<Stock> CreateAsync(Stock stock);

        public Task<Stock> UpdateAsync(Stock stock);

        public Task<bool> DeleteAsync(Guid idStock);
    }
}