using Domain.Core.Event;
using Menu.Domain.ValueObjects;
using Menu.Domain.ValueObjects.Food;

namespace Menu.Domain.Events.FoodEvents
{
    public class FoodUpdatedBasicEvent : IDomainEvent
    {
        public Guid FoodId { get; }
        public Description Description { get; }
        public Img Img { get; }
        public FoodName FoodName { get; }
        public DateTimeOffset UpdatedAt { get; }
        public DateTimeOffset OccurredOn { get; }

        public FoodUpdatedBasicEvent(Guid foodId, Description description, Img img, FoodName foodName, DateTimeOffset updatedAt)
        {
            FoodId = foodId;
            Description = description;
            Img = img;
            FoodName = foodName;
            UpdatedAt = updatedAt;
            OccurredOn = DateTimeOffset.UtcNow;
        }
    }
}