using Domain.Core.Interface;
using Menu.Domain.ValueObjects;

namespace Menu.Domain.Events.FoodEvents
{
    public class FoodUpdatedStatusEvent : IDomainEvent
    {
        public Guid FoodId { get; }
        public DateTimeOffset UpdatedAt { get; }
        public FoodStatus FoodStatus { get; }
        public DateTimeOffset OccurredOn { get; }

        public FoodUpdatedStatusEvent(Guid foodId, DateTimeOffset updatedAt, FoodStatus foodStatus)
        {
            FoodId = foodId;
            UpdatedAt = updatedAt;
            FoodStatus = foodStatus;
            OccurredOn = DateTimeOffset.UtcNow;
        }
    }
}