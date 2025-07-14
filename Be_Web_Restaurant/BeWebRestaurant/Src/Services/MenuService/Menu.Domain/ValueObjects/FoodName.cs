using Domain.Core.Base;
using Domain.Core.Rule;
using Menu.Domain.Common.Factories.Rules;

namespace Menu.Domain.ValueObjects
{
    public sealed class FoodName : ValueObject
    {
        public string Value { get; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        private FoodName(string value)
        {
            Value = value;
        }

        public static FoodName Create(string value)
        {
            RuleValidator.CheckRules(new IBusinessRule[]
            {
                    FoodRuleFactory.NameMaxLength(value),
                    FoodRuleFactory.NameNotEmpty(value)
            });

            return new FoodName(value);
        }

        public static implicit operator string(FoodName foodName) => foodName.Value;

        public override string ToString() => Value;
    }
}