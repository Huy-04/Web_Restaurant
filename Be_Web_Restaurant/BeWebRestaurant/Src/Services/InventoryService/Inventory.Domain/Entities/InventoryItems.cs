using Domain.Core.Base;
using Domain.Core.Rule;
using Inventory.Domain.Common.Factories.Rule;
using Inventory.Domain.Enums;
using Inventory.Domain.Events.InventoryEvents;
using Inventory.Domain.ValueObjects.Common;
using Inventory.Domain.ValueObjects.InventoryItems;

namespace Inventory.Domain.Entities
{
    public sealed class InventoryItems : AggregateRoot
    {
        public Guid IngredientsId { get; private set; }

        public Guid InventoryId { get; private set; }

        public Measurement Measurement { get; private set; }

        public Capacity Capacity { get; private set; }

        public InventoryItemsStatus InventoryStatus { get; private set; }

        public DateTimeOffset CreatedAt { get; private set; }

        public DateTimeOffset UpdatedAt { get; private set; }

        // for orm
        private InventoryItems()
        {
        }

        private InventoryItems(Guid id, Guid ingredientsId, Guid inventoryId, Measurement measurement, Capacity capacity, InventoryItemsStatus inventoryStatus)
            : base(id)
        {
            IngredientsId = ingredientsId;
            InventoryId = inventoryId;
            Measurement = measurement;
            Capacity = capacity;
            InventoryStatus = inventoryStatus;
            CreatedAt = UpdatedAt = DateTimeOffset.UtcNow;
        }

        public static InventoryItems Create(Guid ingredientsId, Guid inventoryId, Capacity capacity, UnitEnum unit)
        {
            var entity = new InventoryItems(Guid.NewGuid(), ingredientsId, inventoryId, Measurement.Create(0, unit), capacity, InventoryItemsStatus.Create(InventoryItemsStatusEnum.OutOfStock));
            return entity;
        }

        public void IncreaseMeasurement(Measurement delta)
        {
            var newMeasurement = Measurement + delta;
            RuleValidator.CheckRules(new IBusinessRule[]
            {
                InventoryItemsRuleFactory.ExceedCapacity(newMeasurement,Capacity)
            });
            Measurement = newMeasurement;
            Touch();
        }

        public void DecreaseMeasurement(Measurement delta)
        {
            Measurement = Measurement - delta;
            Touch();
        }

        public void UpdateMeasurement(Measurement measurement)
        {
            if (Measurement == measurement) return;
            var newMeasurement = measurement;
            RuleValidator.CheckRules(new IBusinessRule[]
            {
                InventoryItemsRuleFactory.ExceedCapacity(newMeasurement,Capacity)
            });
            Measurement = newMeasurement;
            Touch();
        }

        public void UpdateCapacity(Capacity capacity)
        {
            if (Capacity == capacity) return;
            Capacity = capacity;
            Touch();
        }

        public void UpdateStatus(InventoryItemsStatus inventoryStatus)
        {
            if (InventoryStatus == inventoryStatus) return;
            InventoryStatus = inventoryStatus;
            Touch();
            AddDomainEvent(new InventoryItemsUpdateStatusEvent(Id, InventoryStatus, UpdatedAt));
        }

        public void UpdateIngredientsId(Guid ingredientsId)
        {
            if (IngredientsId == ingredientsId) return;
            IngredientsId = ingredientsId;
            Touch();
        }

        public void UpdateInventoryId(Guid inventoryId)
        {
            if (InventoryId == inventoryId) return;
            InventoryId = inventoryId;
            Touch();
        }

        public void OutOfStock() => UpdateStatus(InventoryItemsStatus.Create(InventoryItemsStatusEnum.OutOfStock));

        public void Available() => UpdateStatus(InventoryItemsStatus.Create(InventoryItemsStatusEnum.Available));

        public void LowStock() => UpdateStatus(InventoryItemsStatus.Create(InventoryItemsStatusEnum.LowStock));

        public void Restocking() => UpdateStatus(InventoryItemsStatus.Create(InventoryItemsStatusEnum.Restocking));

        private void Touch()
        {
            UpdatedAt = DateTimeOffset.UtcNow;
        }
    }
}