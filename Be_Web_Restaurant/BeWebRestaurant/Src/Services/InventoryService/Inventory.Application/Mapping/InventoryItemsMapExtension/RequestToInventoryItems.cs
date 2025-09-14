using Inventory.Application.DTOs.Requests.InventoryItems;
using Inventory.Domain.Entities;
using Inventory.Domain.ValueObjects.Common;
using Inventory.Domain.ValueObjects.InventoryItems;

namespace Inventory.Application.Mapping.InventoryItemsMapExtension
{
    public static class RequestToInventoryItems
    {
        public static InventoryItems ToInventoryItems(this CreateInventoryItemsRequest request)
        {
            return InventoryItems.Create(request.IngredientsId, request.InventoryId,
                Capacity.Create(request.Capacity));
        }

        public static Quantity ToQuantity(this UpdateInventoryItemsRequest request)
        {
            return Quantity.Create(request.Quantity);
        }

        public static Capacity ToCapacity(this UpdateInventoryItemsRequest request)
        {
            return Capacity.Create(request.Capacity);
        }

        public static InventoryItemsStatus ToInventoryStatus(this UpdateInventoryItemsRequest request)
        {
            return InventoryItemsStatus.Create(request.InventoryStatus);
        }

        public static void ApplyCapacity(this InventoryItems inventory, UpdateInventoryItemsRequest request)
        {
            inventory.UpdateCapicity(request.ToCapacity());
        }

        public static void ApplyStatus(this InventoryItems inventory, UpdateInventoryItemsRequest request)
        {
            inventory.UpdateStatus(request.ToInventoryStatus());
        }

        public static void ApplyQuantity(this InventoryItems inventory, UpdateInventoryItemsRequest request)
        {
            inventory.UpdateQuantity(request.ToQuantity());
        }
    }
}