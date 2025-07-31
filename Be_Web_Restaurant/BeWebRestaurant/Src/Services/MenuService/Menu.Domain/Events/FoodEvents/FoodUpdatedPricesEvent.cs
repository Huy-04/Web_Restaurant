using Domain.Core.Event;
using Domain.Core.ValueObjects;

namespace Menu.Domain.Events.FoodEvents
{
    public class FoodUpdatedPricesEvent : IDomainEvent
    {
        public Guid FoodId { get; }
        public PriceList Prices { get; }
        public DateTimeOffset UpdatedAt { get; }
        public DateTimeOffset OccurredOn { get; }

        public FoodUpdatedPricesEvent(Guid foodId, PriceList priceList, DateTimeOffset updatedAt)
        {
            FoodId = foodId;
            Prices = priceList;
            UpdatedAt = updatedAt;
            OccurredOn = DateTimeOffset.UtcNow;
        }
    }
}