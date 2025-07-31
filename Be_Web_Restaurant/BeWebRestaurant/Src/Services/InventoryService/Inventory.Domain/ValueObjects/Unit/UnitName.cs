using Domain.Core.Base;
using Domain.Core.Rule;
using Inventory.Domain.Common.Factories.Rule;

namespace Inventory.Domain.ValueObjects.Unit
{
    public sealed class UnitName : ValueObject
    {
        public string Value { get; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        private UnitName(string value)
        {
            Value = value;
        }

        public UnitName Create(string value)
        {
            RuleValidator.CheckRules(new IBusinessRule[]
            {
                UnitRuleFactory.NameMaxLength(value),
                UnitRuleFactory.NameNotEmpty(value)
            });
            return new UnitName(value);
        }

        public static implicit operator string(UnitName unitName) => unitName.Value;

        public override string ToString() => Value;
    }
}