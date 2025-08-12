using Domain.Core.Event;
using Inventory.Domain.ValueObjects.Inventory;

namespace Inventory.Domain.Events.InventoryEvents
{
    public class InventoryUpdateStatusEvent : IDomainEvent
    {
        public Guid IdIventory { get; }

        public InventoryStatus InventoryStatus { get; }

        public DateTimeOffset UpdatedAt { get; }

        public DateTimeOffset OccurredOn { get; }

        public InventoryUpdateStatusEvent(Guid idIventory, InventoryStatus inventoryStatus, DateTimeOffset updatedAt)
        {
            IdIventory = idIventory;
            InventoryStatus = inventoryStatus;
            UpdatedAt = updatedAt;
            OccurredOn = DateTimeOffset.UtcNow;
        }
    }
}