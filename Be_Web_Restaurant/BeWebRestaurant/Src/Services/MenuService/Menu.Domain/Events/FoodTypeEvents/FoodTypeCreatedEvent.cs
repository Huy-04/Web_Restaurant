using Domain.Core.Interface;

namespace Menu.Domain.Events.FoodTypeEvents
{
    public class FoodTypeCreatedEvent : IDomainEvent
    {
        public Guid FoodTypeId { get; }
        public DateTimeOffset OccurredOn { get; }

        public FoodTypeCreatedEvent(Guid foodTypeId)
        {
            FoodTypeId = foodTypeId;
            OccurredOn = DateTimeOffset.UtcNow;
        }
    }
}