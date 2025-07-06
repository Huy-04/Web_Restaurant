using Domain.Core.Interface;

namespace Menu.Domain.Events.FoodEvents
{
    public class FoodChangeFoodTypeIdEvent : IDomainEvent
    {
        public Guid FoodId { get; }
        public Guid FoodTypeId { get; }
        public DateTimeOffset OccurredOn { get; }
        public DateTimeOffset UpdatedAt { get; }

        public FoodChangeFoodTypeIdEvent(Guid foodId, Guid foodTypeId, DateTimeOffset updatedAt)
        {
            FoodId = foodId;
            FoodTypeId = foodTypeId;
            UpdatedAt = updatedAt;
            OccurredOn = DateTimeOffset.UtcNow;
        }
    }
}