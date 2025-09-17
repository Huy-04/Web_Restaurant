using Inventory.Domain.Entities;
using Inventory.Domain.ValueObjects.StockItems;

namespace Inventory.Application.Interfaces
{
    public interface IStockItemsRepository
    {
        Task<IEnumerable<StockItems>> GetAllAsync();

        Task<StockItems?> GetByIdAsync(Guid idStockItems);

        Task<IEnumerable<StockItems>> GetByIngredientsAsync(Guid ingredientsId);

        Task<IEnumerable<StockItems>> GetByStockAsync(Guid stockId);

        Task<IEnumerable<StockItems>> GetByStatusAsync(StockItemsStatus stockItemsStatus);

        Task<StockItems> CreateAsync(StockItems stockItems);

        Task<StockItems> UpdateAsync(StockItems stockItems);

        Task<bool> DeleteAsync(Guid idStockItems);
    }
}