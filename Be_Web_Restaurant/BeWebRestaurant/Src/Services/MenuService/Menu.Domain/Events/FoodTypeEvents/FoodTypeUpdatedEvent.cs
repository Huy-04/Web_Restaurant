using Domain.Core.Interface;

namespace Menu.Domain.Events.FoodTypeEvents
{
    public class FoodTypeUpdatedEvent : IDomainEvent
    {
        public Guid FoodTypeId { get; }
        public DateTimeOffset UpdatedAt { get; }
        public DateTimeOffset OccurredOn { get; }

        public FoodTypeUpdatedEvent(Guid foodTypeId, DateTimeOffset updatedAt)
        {
            FoodTypeId = foodTypeId;
            UpdatedAt = updatedAt;
            OccurredOn = DateTimeOffset.UtcNow;
        }
    }
}