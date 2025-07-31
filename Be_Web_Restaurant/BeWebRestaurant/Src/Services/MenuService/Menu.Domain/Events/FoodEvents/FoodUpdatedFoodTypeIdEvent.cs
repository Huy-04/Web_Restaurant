using Domain.Core.Event;

namespace Menu.Domain.Events.FoodEvents
{
    public class FoodUpdatedFoodTypeIdEvent : IDomainEvent
    {
        public Guid FoodId { get; }
        public Guid FoodTypeId { get; }
        public DateTimeOffset OccurredOn { get; }
        public DateTimeOffset UpdatedAt { get; }

        public FoodUpdatedFoodTypeIdEvent(Guid foodId, Guid foodTypeId, DateTimeOffset updatedAt)
        {
            FoodId = foodId;
            FoodTypeId = foodTypeId;
            UpdatedAt = updatedAt;
            OccurredOn = DateTimeOffset.UtcNow;
        }
    }
}