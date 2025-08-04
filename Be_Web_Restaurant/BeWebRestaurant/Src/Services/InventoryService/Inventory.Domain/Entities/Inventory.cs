using Domain.Core.Base;
using Domain.Core.ValueObjects;
using Inventory.Domain.ValueObjects.Inventory;

namespace Inventory.Domain.Entities
{
    public sealed class Inventory : AggregateRoot
    {
        public Guid IngredientsId { get; private set; }

        public Quantity<decimal> Quantity { get; private set; }

        public InventoryStatus InventoryStatus { get; private set; }

        public DateTimeOffset CreatedAt { get; private set; }

        public DateTimeOffset UpdatedAt { get; private set; }

        // for orm
        private Inventory()
        {
        }

        private Inventory(Guid id, Guid ingredientsId, Quantity<decimal> quantity, InventoryStatus inventoryStatus)
            : base(id)
        {
            IngredientsId = ingredientsId;
            Quantity = quantity;
            InventoryStatus = inventoryStatus;
            CreatedAt = UpdatedAt = DateTimeOffset.UtcNow;
        }

        public static Inventory Create(Guid ingredientsId, Quantity<decimal> quantity, InventoryStatus inventoryStatus)
        {
            var entity = new Inventory(Guid.NewGuid(), ingredientsId, quantity, inventoryStatus);
            return entity;
        }

        public void Update(Guid ingredientsId, Quantity<decimal> quantity, InventoryStatus inventoryStatus)
        {
            IngredientsId = ingredientsId;
            Quantity = quantity;
            InventoryStatus = inventoryStatus;
            UpdatedAt = DateTimeOffset.UtcNow;
        }
    }
}