using Inventory.Domain.ValueObjects.Common;
using Inventory.Domain.ValueObjects.InventoryItems;

namespace Inventory.Application.DTOs.Requests.InventoryItems
{
    public sealed record UpdateInventoryItemsRequest
        (Guid IngredientsId,
        Guid InventoryId,
        Quantity Quantity,
        Capacity Capacity,
        InventoryItemsStatus InventoryStatus)
    {
    }
}