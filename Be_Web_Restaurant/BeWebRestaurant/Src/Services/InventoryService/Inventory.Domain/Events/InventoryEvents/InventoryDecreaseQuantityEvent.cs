using Domain.Core.Event;
using Inventory.Domain.ValueObjects.Common;

namespace Inventory.Domain.Events.InventoryEvents
{
    public class InventoryDecreaseQuantityEvent : IDomainEvent
    {
        public Guid InventoryId { get; }

        public Quantity Delta { get; }

        public Quantity Quantity { get; }

        public DateTimeOffset UpdatedAt { get; }

        public DateTimeOffset OccurredOn { get; }

        public InventoryDecreaseQuantityEvent(Guid inventoryId, Quantity delta, Quantity quantity, DateTimeOffset updatedAt)
        {
            InventoryId = inventoryId;
            Delta = delta;
            Quantity = quantity;
            UpdatedAt = updatedAt;
            OccurredOn = DateTimeOffset.UtcNow;
        }
    }
}