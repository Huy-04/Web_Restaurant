using Domain.Core.Base;
using Domain.Core.ValueObjects;
using Menu.Domain.Enums;
using Menu.Domain.Events.FoodEvents;
using Menu.Domain.ValueObjects.Food;

namespace Menu.Domain.Entities
{
    public sealed class Food : AggregateRoot
    {
        // vo
        public FoodName FoodName { get; private set; }

        public PriceList Prices { get; private set; }

        public Img Img { get; private set; }

        public Description Description { get; private set; }

        public FoodStatus FoodStatus { get; private set; }

        // time
        public DateTimeOffset CreatedAt { get; private set; }

        public DateTimeOffset UpdatedAt { get; private set; }

        // relationship
        public Guid FoodTypeId { get; private set; }

        // for orm
        private Food()
        { }

        private Food(Guid id, FoodName foodName, PriceList prices, Guid foodTypeId, Img img, Description description, FoodStatus foodStatus)
            : base(id)
        {
            FoodName = foodName;
            Prices = prices;
            FoodTypeId = foodTypeId;
            Img = img;
            Description = description;
            FoodStatus = foodStatus;
            CreatedAt = UpdatedAt = DateTimeOffset.UtcNow;
        }

        public static Food Create(FoodName foodName, PriceList prices, Guid foodTypeId, Img img, Description description)
        {
            var food = new Food(Guid.NewGuid(), foodName, prices, foodTypeId, img, description, FoodStatusEnum.Active);

            var foodCreatedEvent = new FoodCreatedEvent(food.Id, foodName, description, img, foodTypeId, food.FoodStatus);

            food.AddDomainEvent(foodCreatedEvent);

            return food;
        }

        // behavior
        public void UpdateBasic(FoodName foodName, Img img, Description description)
        {
            if (FoodName == foodName && Img == img && Description == description) return;
            FoodName = foodName;
            Img = img;
            Description = description;
            Touch();

            AddDomainEvent(new FoodUpdatedBasicEvent(Id, Description, Img, FoodName, UpdatedAt));
        }

        public void UpdateStatus(FoodStatus foodStatus)
        {
            if (FoodStatus == foodStatus) return;
            FoodStatus = foodStatus;
            Touch();

            AddDomainEvent(new FoodUpdatedStatusEvent(Id, UpdatedAt, FoodStatus));
        }

        public void MarkAsActive() => UpdateStatus(FoodStatus.Create(FoodStatusEnum.Active));

        public void MarkAsDiscontinued() => UpdateStatus(FoodStatus.Create(FoodStatusEnum.Discontinued));

        public void UpdateFoodTypeId(Guid foodTypeId)
        {
            if (FoodTypeId == foodTypeId) return;
            FoodTypeId = foodTypeId;
            Touch();

            AddDomainEvent(new FoodUpdatedFoodTypeIdEvent(Id, FoodTypeId, UpdatedAt));
        }

        public void UpdatePrice(PriceList priceList)
        {
            if (Prices.Equals(priceList)) return;
            Prices = priceList;
            Touch();

            AddDomainEvent(new FoodUpdatedPricesEvent(Id, Prices, UpdatedAt));
        }

        // extenstion
        private void Touch()
        {
            UpdatedAt = DateTimeOffset.UtcNow;
        }
    }
}