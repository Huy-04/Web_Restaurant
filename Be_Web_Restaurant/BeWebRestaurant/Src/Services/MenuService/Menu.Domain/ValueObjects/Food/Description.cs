using Domain.Core.Base;
using Domain.Core.Rule;
using Menu.Domain.Common.Factories.Rules;

namespace Menu.Domain.ValueObjects.Food
{
    public sealed class Description : ValueObject
    {
        public string Value { get; }

        private Description(string value)
        {
            Value = value;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        public static Description Create(string value)
        {
            RuleValidator.CheckRules(new IBusinessRule[]
            {
                FoodRuleFactory.DescriptionMaxLength(value),
                FoodRuleFactory.DescriptionNotEmpty(value)
            });
            return new Description(value);
        }

        public static implicit operator string(Description description) => description.Value;

        public override string ToString() => Value;
    }
}