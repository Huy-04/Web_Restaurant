using Domain.Core.Rule;
using Domain.Core.Rule.EnumRule;
using Domain.Core.Rule.NumberRule;
using Inventory.Domain.Common.Messages.ErrorMessages;
using Inventory.Domain.Common.Messages.FieldNames;
using Inventory.Domain.Enums;
using Inventory.Domain.ValueObjects.Inventory;

namespace Inventory.Domain.Common.Factories.Rule
{
    public static class InventoryRuleFactory
    {
        // Inventory Status
        public static IBusinessRule InventoryStatusValidate(InventoryStatusEnum inventoryStatus)
        {
            var validate = Enum.GetValues(typeof(InventoryStatusEnum)).Cast<InventoryStatusEnum>().ToList();
            return new EnumValidateRule<InventoryStatusEnum>(inventoryStatus, validate, InventoryField.InventoryStatus, InventoryErrors.InvalidInventoryStatusValue);
        }

        // Quantity
        public static IBusinessRule QuantityNotNegative(decimal quantity)
        {
            return new NotNegativeRule<decimal>(quantity, InventoryField.Quantity, InventoryErrors.QuantityMustNotBeNegative);
        }
    }
}