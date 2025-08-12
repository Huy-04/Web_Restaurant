using Domain.Core.Rule;
using Domain.Core.Rule.StringRule;
using Inventory.Domain.Common.Messages.ErrorMessages;
using Inventory.Domain.Common.Messages.FieldNames;

namespace Inventory.Domain.Common.Factories.Rule
{
    public static class StockReceiptRuleFactory
    {
        public static IBusinessRule NameMaxLength(string value)
        {
            return new StringMaxLength(value, 50, StockReceipField.Supplier, StockReceipErrors.SupplierMaxLengthExceeded);
        }

        public static IBusinessRule NameNotEmpty(string value)
        {
            return new StringNotEmpty(value, StockReceipField.Supplier, StockReceipErrors.SupplierMustNotBeEmpty);
        }
    }
}