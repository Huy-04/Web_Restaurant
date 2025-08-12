using Domain.Core.Event;
using Domain.Core.ValueObjects;
using Menu.Domain.ValueObjects.Food;

namespace Menu.Domain.Events.FoodEvents
{
    public class FoodUpdatedBasicEvent : IDomainEvent
    {
        public Guid IdFood { get; }
        public Description Description { get; }
        public Img Img { get; }
        public FoodName FoodName { get; }
        public DateTimeOffset UpdatedAt { get; }
        public DateTimeOffset OccurredOn { get; }

        public FoodUpdatedBasicEvent(Guid idFood, Description description, Img img, FoodName foodName, DateTimeOffset updatedAt)
        {
            IdFood = idFood;
            Description = description;
            Img = img;
            FoodName = foodName;
            UpdatedAt = updatedAt;
            OccurredOn = DateTimeOffset.UtcNow;
        }
    }
}