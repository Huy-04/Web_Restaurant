using Domain.Core.Event;
using Inventory.Domain.ValueObjects.Common;
using Inventory.Domain.ValueObjects.Inventory;

namespace Inventory.Domain.Events.InventoryEvents
{
    public class InventoryCreateEvent : IDomainEvent
    {
        public Guid IngredientsId { get; }

        public Quantity Quantity { get; }

        public InventoryStatus InventoryStatus { get; }

        public DateTimeOffset OccurredOn { get; }

        public InventoryCreateEvent(Guid ingredientsId, Quantity quantity, InventoryStatus inventoryStatus)
        {
            IngredientsId = ingredientsId;
            Quantity = quantity;
            InventoryStatus = inventoryStatus;
            OccurredOn = DateTimeOffset.UtcNow;
        }
    }
}