using Inventory.Application.DTOs.Responses.InventoryItems;
using Inventory.Domain.Entities;

namespace Inventory.Application.Mapping.InventoryItemsMapExtension
{
    public static class InventoryItemsToResponse
    {
        public static InventoryItemsResponse ToInventoryItemsResponse
            (this InventoryItems inventory, string ingredientsName)
        {
            return new(inventory.Id,
                inventory.IngredientsId,
                inventory.InventoryId,
                ingredientsName,
                inventory.Quantity,
                inventory.Capacity,
                inventory.InventoryStatus,
                inventory.CreatedAt,
                inventory.UpdatedAt);
        }
    }
}