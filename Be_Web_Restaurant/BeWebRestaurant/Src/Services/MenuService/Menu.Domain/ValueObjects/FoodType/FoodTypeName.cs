using Domain.Core.Base;
using Domain.Core.Rule;
using Menu.Domain.Common.Factories.Rules;

namespace Menu.Domain.ValueObjects.FoodType
{
    public sealed class FoodTypeName : ValueObject
    {
        public string Value { get; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        private FoodTypeName(string value)
        {
            Value = value;
        }

        public static FoodTypeName Create(string value)
        {
            RuleValidator.CheckRules(new IBusinessRule[]
            {
                FoodTypeRuleFactory.NameMaxLength(value),
                FoodTypeRuleFactory.NameNotEmpty(value)
            });

            return new FoodTypeName(value);
        }

        public static implicit operator string(FoodTypeName foodTypeName) => foodTypeName.Value;

        public override string ToString() => Value;
    }
}