using Domain.Core.Rule;
using Domain.Core.ValueObjects;
using Inventory.Domain.Common.Factories.Rule;

namespace Inventory.Domain.ValueObjects.StockReceipt
{
    public sealed class Supplier : Name
    {
        private Supplier(string value) : base(value)
        {
            RuleValidator.CheckRules(new IBusinessRule[]
            {
                StockReceiptRuleFactory.NameMaxLength(value),
                StockReceiptRuleFactory.NameNotEmpty(value)
            });
        }

        public Supplier Create(string value)
        {
            return new Supplier(value);
        }
    }
}