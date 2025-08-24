using Inventory.Domain.ValueObjects.Inventory;
using InventoryEntity = Inventory.Domain.Entities.Inventory;

namespace Inventory.Application.Interfaces
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<InventoryEntity>> GetAllAsync();

        Task<InventoryEntity?> GetByIdAsync(Guid idInventory);

        Task<IEnumerable<InventoryEntity>> GetByIngredientsAsync(Guid ingredientsId);

        Task<IEnumerable<InventoryEntity>> GetByStatusAsync(InventoryStatus inventoryStatus);

        Task<InventoryEntity> CreateAsync(InventoryEntity inventory);

        Task<InventoryEntity> UpdateAsync(InventoryEntity inventory);

        Task<bool> DeleteAsync(Guid idInventory);
    }
}