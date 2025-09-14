using Domain.Core.Base;
using Domain.Core.Rule;
using Domain.Core.Rule.EnumRule;
using Domain.Core.ValueObjects;
using Inventory.Domain.Common.Factories.Rule;
using Inventory.Domain.Enums;

namespace Inventory.Domain.ValueObjects.InventoryItems
{
    public sealed class InventoryItemsStatus : Status<InventoryItemsStatusEnum>
    {
        private InventoryItemsStatus(InventoryItemsStatusEnum inventoryStatus) : base(inventoryStatus)
        {
            RuleValidator.CheckRules(new IBusinessRule[]
            {
                InventoryItemsRuleFactory.InventoryItemsStatusValidate(inventoryStatus)
            });
        }

        public static InventoryItemsStatus Create(InventoryItemsStatusEnum inventoryStatus)
        {
            return new InventoryItemsStatus(inventoryStatus);
        }

        public static implicit operator InventoryItemsStatusEnum(InventoryItemsStatus inventoryStatus) => inventoryStatus.Value;

        public static implicit operator InventoryItemsStatus(InventoryItemsStatusEnum inventoryStatusEnum) => Create(inventoryStatusEnum);
    }
}