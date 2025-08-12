using Domain.Core.Event;
using Menu.Domain.Entities;

namespace Menu.Domain.Events.FoodEvents
{
    public class FoodUpdatedFoodTypeIdEvent : IDomainEvent
    {
        public Guid IdFood { get; }
        public Guid FoodTypeId { get; }
        public DateTimeOffset OccurredOn { get; }
        public DateTimeOffset UpdatedAt { get; }

        public FoodUpdatedFoodTypeIdEvent(Guid idFood, Guid foodTypeId, DateTimeOffset updatedAt)
        {
            IdFood = idFood;
            FoodTypeId = foodTypeId;
            UpdatedAt = updatedAt;
            OccurredOn = DateTimeOffset.UtcNow;
        }
    }
}