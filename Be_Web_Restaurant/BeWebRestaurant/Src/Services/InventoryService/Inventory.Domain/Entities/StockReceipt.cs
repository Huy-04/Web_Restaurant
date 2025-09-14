using Domain.Core.Base;
using Domain.Core.ValueObjects;
using Inventory.Domain.ValueObjects.Common;
using Inventory.Domain.ValueObjects.StockReceipt;

namespace Inventory.Domain.Entities
{
    public sealed class StockReceipt : AggregateRoot
    {
        public Guid IngredientsId { get; private set; }

        public Measurement Measurement { get; private set; }

        public Money Money { get; private set; }

        public Supplier Supplier { get; private set; }

        public DateTimeOffset Importdate { get; private set; }

        // for orm
        private StockReceipt()
        { }

        private StockReceipt(Guid id, Guid ingredientsId, Measurement measurement, Money money, Supplier supplier)
            : base(id)
        {
            IngredientsId = ingredientsId;
            Measurement = measurement;
            Money = money;
            Supplier = supplier;
            Importdate = DateTimeOffset.UtcNow;
        }

        public static StockReceipt Create(Guid ingredientsId, Measurement measurement, Money money, Supplier supplier)
        {
            var entity = new StockReceipt(Guid.NewGuid(), ingredientsId, measurement, money, supplier);
            return entity;
        }

        public void Update(Guid ingredientsId, Measurement measurement, Money money, Supplier supplier)
        {
            if (IngredientsId == ingredientsId && Measurement == measurement && Money == money && Supplier == supplier) return;
            IngredientsId = ingredientsId;
            Measurement = measurement;
            Money = money;
            Supplier = supplier;
        }
    }
}