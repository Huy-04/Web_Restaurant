using Inventory.Application.DTOs.Requests.Inventory;
using Inventory.Domain.ValueObjects.Inventory;
using InventoryEntity = Inventory.Domain.Entities.Inventory;

namespace Inventory.Application.Mapping.InventoryMapExtension
{
    public static class RequestToInventory
    {
        public static InventoryEntity ToInventory(this CreateInventoryRequest request)
        {
            return InventoryEntity.Create(request.IngredientsId,
                Capacity.Create(request.Capacity));
        }
    }
}