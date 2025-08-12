using Inventory.Domain.ValueObjects.Inventory;

namespace Inventory.Application.DTOs.Requests.Inventory
{
    public sealed record CreateInventoryRequest(
        Guid IngredientsId, decimal Capacity)
    {
    }
}