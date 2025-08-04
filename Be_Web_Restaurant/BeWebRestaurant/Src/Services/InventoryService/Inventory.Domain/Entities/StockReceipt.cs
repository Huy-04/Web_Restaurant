using Domain.Core.Base;
using Domain.Core.ValueObjects;
using Inventory.Domain.ValueObjects.StockReceipt;

namespace Inventory.Domain.Entities
{
    public sealed class StockReceipt : AggregateRoot
    {
        public Guid IngredientsId { get; private set; }

        public Quantity<decimal> Quantity { get; private set; }

        public Guid UnitId { get; private set; }

        public PriceList Prices { get; private set; }

        public Supplier Supplier { get; private set; }

        public DateTimeOffset CreatedAt { get; private set; }

        public DateTimeOffset UpdatedAt { get; private set; }

        // for orm
        private StockReceipt()
        { }

        private StockReceipt(Guid id, Guid ingredientsId, Guid unitId, PriceList prices, Supplier supplier)
            : base(id)
        {
            IngredientsId = ingredientsId;
            UnitId = unitId;
            Prices = prices;
            Supplier = supplier;
            CreatedAt = UpdatedAt = DateTimeOffset.UtcNow;
        }

        public static StockReceipt Create(Guid ingredientsId, Guid unitId, PriceList prices, Supplier supplier)
        {
            var entity = new StockReceipt(Guid.NewGuid(), ingredientsId, unitId, prices, supplier);
            return entity;
        }

        public void Update(Guid ingredientsId, Guid unitId, PriceList prices, Supplier supplier)
        {
            IngredientsId = ingredientsId;
            UnitId = unitId;
            Prices = prices;
            Supplier = supplier;
            UpdatedAt = DateTimeOffset.UtcNow;
        }
    }
}