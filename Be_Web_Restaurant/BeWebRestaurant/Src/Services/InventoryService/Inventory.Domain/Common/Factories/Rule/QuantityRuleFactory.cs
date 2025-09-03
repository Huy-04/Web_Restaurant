using Domain.Core.Rule.NumberRule;
using Domain.Core.Rule;
using Inventory.Domain.Common.Messages.FieldNames;

namespace Inventory.Domain.Common.Factories.Rule
{
    public static class QuantityRuleFactory
    {
        // Quantity
        public static IBusinessRule QuantityNotNegative(decimal quantity)
        {
            return new NotNegativeRule<decimal>(quantity, InventoryField.Quantity);
        }
    }
}