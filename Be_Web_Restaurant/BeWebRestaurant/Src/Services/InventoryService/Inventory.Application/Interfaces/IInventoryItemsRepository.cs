using Inventory.Domain.Entities;
using Inventory.Domain.ValueObjects.InventoryItems;

namespace Inventory.Application.Interfaces
{
    public interface IInventoryItemsRepository
    {
        Task<IEnumerable<InventoryItems>> GetAllAsync();

        Task<InventoryItems?> GetByIdAsync(Guid idInventory);

        Task<IEnumerable<InventoryItems>> GetByIngredientsAsync(Guid ingredientsId);

        Task<IEnumerable<InventoryItems>> GetByInventoryAsync(Guid inventoryId);

        Task<IEnumerable<InventoryItems>> GetByStatusAsync(InventoryItemsStatus inventoryStatus);

        Task<InventoryItems> CreateAsync(InventoryItems inventory);

        Task<InventoryItems> UpdateAsync(InventoryItems inventory);

        Task<bool> DeleteAsync(Guid idInventory);
    }
}