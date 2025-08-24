using Inventory.Domain.ValueObjects.Inventory;

namespace Inventory.Application.DTOs.Responses.Inventory
{
    public sealed record InventoryResponse(
        Guid IdInventory,
        Guid IngredientsId,
        string ingredientsName,
        decimal Quantity,
        decimal Capacity,
        InventoryStatus InventoryStatus,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt
        )
    {
    }
}