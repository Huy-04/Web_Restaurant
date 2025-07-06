using Domain.Core.Interface;
using Menu.Domain.ValueObjects;

namespace Menu.Domain.Events.FoodEvents
{
    public class FoodCreatedEvent : IDomainEvent
    {
        public Guid FoodId { get; }
        public Guid FoodTypeId { get; }
        public FoodStatus FoodStatus { get; }
        public DateTimeOffset OccurredOn { get; }

        public FoodCreatedEvent(Guid foodId, Guid foodTypeId, FoodStatus foodStatus)
        {
            FoodId = foodId;
            FoodTypeId = foodTypeId;
            FoodStatus = foodStatus;
            OccurredOn = DateTimeOffset.UtcNow;
        }
    }
}