namespace Inventory.Application.DTOs.Requests.InventoryItems
{
    public sealed record CreateInventoryItemsRequest(
        Guid IngredientsId, Guid InventoryId, decimal Capacity)
    {
    }
}