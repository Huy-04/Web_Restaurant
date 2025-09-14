using Domain.Core.Rule;
using Domain.Core.Rule.EnumRule;
using Domain.Core.Rule.NumberRule;
using Inventory.Domain.Common.Messages.FieldNames;
using Inventory.Domain.Enums;
using Inventory.Domain.ValueObjects.Common;
using Inventory.Domain.ValueObjects.InventoryItems;

namespace Inventory.Domain.Common.Factories.Rule
{
    public static class InventoryItemsRuleFactory
    {
        // InventoryItems Status
        public static IBusinessRule InventoryItemsStatusValidate(InventoryItemsStatusEnum inventoryStatus)
        {
            var validate = Enum.GetValues(typeof(InventoryItemsStatusEnum)).Cast<InventoryItemsStatusEnum>().ToList();
            return new EnumValidateRule<InventoryItemsStatusEnum>(inventoryStatus, validate, InventoryItemsField.InventoryItemsStatus);
        }

        public static IBusinessRule ExceedCapacity(Measurement measurement, Capacity capacity)
        {
            return new MaxValueLimitRule<decimal>(measurement.Value, capacity.Value, InventoryItemsField.Measurement);
        }
    }
}