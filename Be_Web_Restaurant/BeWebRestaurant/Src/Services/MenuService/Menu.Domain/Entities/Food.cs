using Domain.Core.Base;
using Menu.Domain.Common.Factories.Catalog;
using Menu.Domain.Events.FoodEvents;
using Menu.Domain.ValueObjects;

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
            var food = new Food(Guid.NewGuid(), foodName, prices, foodTypeId, img, description, FoodStatusCatalog.Available);

            var foodCreateEvent = new FoodCreatedEvent(food.Id, foodTypeId, food.FoodStatus);

            food.AddDomainEvent(foodCreateEvent);

            return food;
        }

        // behavior
        public void UpdateBasic(FoodName foodName, Img img, Description description)
        {
            FoodName = foodName;
            Img = img;
            Description = description;
            Touch();

            AddDomainEvent(new FoodUpdatedBasicEvent(Id, description, img, foodName, UpdatedAt));
        }

        public void ChangeStatus(FoodStatus foodStatus)
        {
            if (FoodStatus == foodStatus) return;
            FoodStatus = foodStatus;
            Touch();

            AddDomainEvent(new FoodChangeStatusEvent(Id, UpdatedAt, foodStatus));
        }

        public void MarkAsAvailable() => ChangeStatus(FoodStatusCatalog.Available);

        public void MarkAsOutOfStock() => ChangeStatus(FoodStatusCatalog.OutOfStock);

        public void MarkAsDiscontinued() => ChangeStatus(FoodStatusCatalog.Discontinued);

        public void ChangeFoodTypeId(Guid foodTypeId)
        {
            FoodTypeId = foodTypeId;
            Touch();

            AddDomainEvent(new FoodChangeFoodTypeIdEvent(Id, foodTypeId, UpdatedAt));
        }

        public void SetPrice(PriceList priceList)
        {
            if (Prices.Equals(priceList)) return;
            Prices = priceList;
            Touch();

            AddDomainEvent(new FoodSetPricesEvent(Id, priceList, UpdatedAt));
        }

        // extenstion
        private void Touch()
        {
            UpdatedAt = DateTimeOffset.UtcNow;
        }
    }
}