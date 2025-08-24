using Domain.Core.Base;
using Inventory.Domain.Enums;
using Inventory.Domain.Events.InventoryEvents;
using Inventory.Domain.ValueObjects.Common;
using Inventory.Domain.ValueObjects.Inventory;

namespace Inventory.Domain.Entities
{
    public sealed class Inventory : AggregateRoot
    {
        public Guid IngredientsId { get; private set; }

        public Quantity Quantity { get; private set; }

        public Capacity Capacity { get; private set; }

        public InventoryStatus InventoryStatus { get; private set; }

        public DateTimeOffset CreatedAt { get; private set; }

        public DateTimeOffset UpdatedAt { get; private set; }

        // for orm
        private Inventory()
        {
        }

        private Inventory(Guid id, Guid ingredientsId, Quantity quantity, Capacity capacity, InventoryStatus inventoryStatus)
            : base(id)
        {
            IngredientsId = ingredientsId;
            Quantity = quantity;
            Capacity = capacity;
            InventoryStatus = inventoryStatus;
            CreatedAt = UpdatedAt = DateTimeOffset.UtcNow;
        }

        public static Inventory Create(Guid ingredientsId, Capacity capacity)
        {
            var entity = new Inventory(Guid.NewGuid(), ingredientsId, Quantity.Create(0), capacity, InventoryStatusEnum.OutOfStock);
            entity.AddDomainEvent(new InventoryCreateEvent(ingredientsId, entity.Quantity, entity.InventoryStatus));
            return entity;
        }

        public void IncreaseQuantity(Quantity delta)
        {
            Quantity = Quantity + delta;
            UpdatedAt = DateTimeOffset.UtcNow;
            AddDomainEvent(new InventoryIncreaseQuantityEvent(Id, delta, Quantity, UpdatedAt));
        }

        public void DecreaseQuantity(Quantity delta)
        {
            Quantity = Quantity - delta;
            UpdatedAt = DateTimeOffset.UtcNow;
            AddDomainEvent(new InventoryDecreaseQuantityEvent(Id, delta, Quantity, UpdatedAt));
        }

        public void UpdateCapicity(Capacity capacity)
        {
            if (Capacity == capacity) return;
            Capacity = capacity;
        }

        public void UpdateStatus(InventoryStatus inventoryStatus)
        {
            if (InventoryStatus == inventoryStatus) return;
            InventoryStatus = inventoryStatus;
            Touch();
            AddDomainEvent(new InventoryUpdateStatusEvent(Id, InventoryStatus, UpdatedAt));
        }

        public void UpdateIngredientsId(Guid ingredientsId)
        {
            if (IngredientsId == ingredientsId) return;
            IngredientsId = ingredientsId;
            Touch();
            AddDomainEvent(new InventoryUpdateIngredientsIdEvent(Id, IngredientsId, UpdatedAt));
        }

        public void OutOfStock() => UpdateStatus(InventoryStatus.Create(InventoryStatusEnum.OutOfStock));

        public void Available() => UpdateStatus(InventoryStatus.Create(InventoryStatusEnum.Available));

        public void LowStock() => UpdateStatus(InventoryStatus.Create(InventoryStatusEnum.LowStock));

        public void Restocking() => UpdateStatus(InventoryStatus.Create(InventoryStatusEnum.Restocking));

        private void Touch()
        {
            UpdatedAt = DateTimeOffset.UtcNow;
        }
    }
}