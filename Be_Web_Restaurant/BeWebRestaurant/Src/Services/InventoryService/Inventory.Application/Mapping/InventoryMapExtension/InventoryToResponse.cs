using Inventory.Application.DTOs.Responses.Inventory;
using InventoryEntity = Inventory.Domain.Entities.Inventory;

namespace Inventory.Application.Mapping.InventoryMapExtension
{
    public static class InventoryToResponse
    {
        public static InventoryResponse ToInventoryResponse
            (this InventoryEntity inventory, string ingredientsName)
        {
            return new(inventory.Id,
                inventory.IngredientsId,
                ingredientsName,
                inventory.Quantity,
                inventory.Capacity,
                inventory.InventoryStatus,
                inventory.CreatedAt,
                inventory.UpdatedAt);
        }
    }
}