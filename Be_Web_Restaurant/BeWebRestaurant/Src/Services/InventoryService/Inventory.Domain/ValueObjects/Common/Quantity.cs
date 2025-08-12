using Domain.Core.Rule;
using Inventory.Domain.Common.Factories.Rule;

namespace Inventory.Domain.ValueObjects.Common
{
    public sealed class Quantity : QuantityBase<decimal, Quantity>
    {
        private Quantity(decimal value) : base(value)
        {
        }

        public static Quantity Create(decimal value)
        {
            RuleValidator.CheckRules(new IBusinessRule[]
            {
                InventoryRuleFactory.QuantityNotNegative(value)
            });
            return new Quantity(value);
        }

        protected override Quantity CreateCore(decimal value)
        {
            return Create(value);
        }
    }
}