using Domain.Core.Event;

namespace Inventory.Domain.Events.InventoryEvents
{
    public class InventoryUpdateIngredientsIdEvent : IDomainEvent
    {
        public Guid InventoryId { get; }

        public Guid IngredientsId { get; }

        public DateTimeOffset OccurredOn { get; }

        public DateTimeOffset UpdatedAt { get; }

        public InventoryUpdateIngredientsIdEvent(Guid inventoryId, Guid ingredientsId, DateTimeOffset updatedAt)
        {
            InventoryId = inventoryId;
            IngredientsId = ingredientsId;
            UpdatedAt = updatedAt;
            OccurredOn = DateTimeOffset.UtcNow;
        }
    }
}