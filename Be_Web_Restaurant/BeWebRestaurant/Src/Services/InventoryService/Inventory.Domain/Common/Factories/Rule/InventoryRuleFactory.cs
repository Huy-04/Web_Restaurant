using Domain.Core.Rule;
using Domain.Core.Rule.EnumRule;
using Inventory.Domain.Common.Messages.ErrorMessages;
using Inventory.Domain.Common.Messages.FieldNames;
using Inventory.Domain.Enums;

namespace Inventory.Domain.Common.Factories.Rule
{
    public static class InventoryRuleFactory
    {
        public static IBusinessRule InventoryStatusValidate(InventoryStatusEnum inventoryStatus)
        {
            var validate = Enum.GetValues(typeof(InventoryStatusEnum)).Cast<InventoryStatusEnum>().ToList();
            return new EnumValidateRule<InventoryStatusEnum>(inventoryStatus, validate, InventoryField.InventoryStatus, IventoryMessages.InvalidInventoryStatusValue);
        }
    }
}