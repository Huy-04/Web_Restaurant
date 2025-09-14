using Domain.Core.Event;
using Inventory.Domain.ValueObjects.InventoryItems;

namespace Inventory.Domain.Events.InventoryEvents
{
    public class InventoryItemsUpdateStatusEvent : IDomainEvent
    {
        public Guid IdIventoryItems { get; }

        public InventoryItemsStatus InventoryStatus { get; }

        public DateTimeOffset UpdatedAt { get; }

        public DateTimeOffset OccurredOn { get; }

        public InventoryItemsUpdateStatusEvent(Guid idIventoryItems, InventoryItemsStatus inventoryStatus, DateTimeOffset updatedAt)
        {
            IdIventoryItems = idIventoryItems;
            InventoryStatus = inventoryStatus;
            UpdatedAt = updatedAt;
            OccurredOn = DateTimeOffset.UtcNow;
        }
    }
}