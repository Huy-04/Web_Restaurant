using Domain.Core.Base;
using Domain.Core.Rule;
using Domain.Core.Rule.EnumRule;
using Domain.Core.ValueObjects;
using Inventory.Domain.Common.Factories.Rule;
using Inventory.Domain.Enums;

namespace Inventory.Domain.ValueObjects.Inventory
{
    public sealed class InventoryStatus : Status<InventoryStatusEnum>
    {
        private InventoryStatus(InventoryStatusEnum inventoryStatus) : base(inventoryStatus)
        {
            RuleValidator.CheckRules(new IBusinessRule[]
            {
                InventoryRuleFactory.InventoryStatusValidate(inventoryStatus)
            });
        }

        public static InventoryStatus Create(InventoryStatusEnum inventoryStatus)
        {
            return new InventoryStatus(inventoryStatus);
        }
    }
}