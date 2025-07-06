using Domain.Core.Interface;
using Menu.Domain.ValueObjects;

namespace Menu.Domain.Events.FoodEvents
{
    public class FoodSetPricesEvent : IDomainEvent
    {
        public Guid FoodId { get; }
        public PriceList Prices { get; }
        public DateTimeOffset UpdatedAt { get; }
        public DateTimeOffset OccurredOn { get; }

        public FoodSetPricesEvent(Guid foodId, PriceList priceList, DateTimeOffset updatedAt)
        {
            FoodId = foodId;
            Prices = priceList;
            UpdatedAt = updatedAt;
            OccurredOn = DateTimeOffset.UtcNow;
        }
    }
}