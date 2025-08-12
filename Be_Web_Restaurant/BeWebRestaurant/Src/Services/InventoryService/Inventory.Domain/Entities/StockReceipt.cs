using Domain.Core.Base;
using Domain.Core.ValueObjects;
using Inventory.Domain.ValueObjects.Common;
using Inventory.Domain.ValueObjects.StockReceipt;

namespace Inventory.Domain.Entities
{
    public sealed class StockReceipt : AggregateRoot
    {
        public Guid IngredientsId { get; private set; }

        public Quantity Quantity { get; private set; }

        public Guid UnitId { get; private set; }

        public PriceList Prices { get; private set; }

        public Supplier Supplier { get; private set; }

        public DateTimeOffset Importdate { get; private set; }

        // for orm
        private StockReceipt()
        { }

        private StockReceipt(Guid id, Guid ingredientsId, Quantity quantity, Guid unitId, PriceList prices, Supplier supplier)
            : base(id)
        {
            IngredientsId = ingredientsId;
            Quantity = quantity;
            UnitId = unitId;
            Prices = prices;
            Supplier = supplier;
            Importdate = DateTimeOffset.UtcNow;
        }

        public static StockReceipt Create(Guid ingredientsId, Quantity quantity, Guid unitId, PriceList prices, Supplier supplier)
        {
            var entity = new StockReceipt(Guid.NewGuid(), ingredientsId, quantity, unitId, prices, supplier);
            return entity;
        }

        public void Update(Guid ingredientsId, Quantity quantity, Guid unitId, PriceList prices, Supplier supplier)
        {
            IngredientsId = ingredientsId;
            Quantity = quantity;
            UnitId = unitId;
            Prices = prices;
            Supplier = supplier;
        }
    }
}