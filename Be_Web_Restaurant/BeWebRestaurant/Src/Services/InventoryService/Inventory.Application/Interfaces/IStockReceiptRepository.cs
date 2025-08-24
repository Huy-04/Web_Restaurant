using Inventory.Domain.Entities;
using Inventory.Domain.ValueObjects.StockReceipt;

namespace Inventory.Application.Interfaces
{
    public interface IStockReceiptRepository
    {
        Task<IEnumerable<StockReceipt>> GetAllAsync();

        Task<StockReceipt?> GetByIdAsync(Guid idStockReceipt);

        Task<IEnumerable<StockReceipt>> GetByIngredientsAsync(Guid idngredientsId);

        Task<StockReceipt> CreateAsync(StockReceipt stockReceipt);

        Task<StockReceipt> UpdateAsync(StockReceipt stockReceipt);

        Task<bool> DeleteAsync(Guid idStockReceipt);
    }
}