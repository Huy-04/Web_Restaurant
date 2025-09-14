using Inventory.Domain.ValueObjects.InventoryItems;

namespace Inventory.Application.DTOs.Responses.InventoryItems
{
    public sealed record InventoryItemsResponse(
        Guid IdInventory,
        Guid IngredientsId,
        Guid InventoryId,
        string ingredientsName,
        decimal Quantity,
        decimal Capacity,
        InventoryItemsStatus InventoryStatus,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt
        )
    {
    }
}