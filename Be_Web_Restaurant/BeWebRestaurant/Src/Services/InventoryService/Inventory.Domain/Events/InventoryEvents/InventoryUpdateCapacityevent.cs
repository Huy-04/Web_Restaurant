using Domain.Core.Event;
using Inventory.Domain.ValueObjects.Inventory;

namespace Inventory.Domain.Events.InventoryEvents
{
    public sealed class InventoryUpdateCapacityevent : IDomainEvent
    {
        public Guid IdInventory { get; }

        public Capacity Capacity { get; }

        public DateTimeOffset UpdatedAt { get; }

        public DateTimeOffset OccurredOn { get; }

        public InventoryUpdateCapacityevent(Guid idInventory, Capacity capacity, DateTimeOffset updatedAt)
        {
            IdInventory = idInventory;
            Capacity = capacity;
            UpdatedAt = updatedAt;
            OccurredOn = DateTimeOffset.UtcNow;
        }
    }
}