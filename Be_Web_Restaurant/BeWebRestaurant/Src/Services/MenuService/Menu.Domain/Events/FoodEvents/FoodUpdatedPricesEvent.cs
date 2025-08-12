using Domain.Core.Event;
using Domain.Core.ValueObjects;

namespace Menu.Domain.Events.FoodEvents
{
    public class FoodUpdatedPricesEvent : IDomainEvent
    {
        public Guid IdFood { get; }
        public PriceList Prices { get; }
        public DateTimeOffset UpdatedAt { get; }
        public DateTimeOffset OccurredOn { get; }

        public FoodUpdatedPricesEvent(Guid idFood, PriceList priceList, DateTimeOffset updatedAt)
        {
            IdFood = idFood;
            Prices = priceList;
            UpdatedAt = updatedAt;
            OccurredOn = DateTimeOffset.UtcNow;
        }
    }
}