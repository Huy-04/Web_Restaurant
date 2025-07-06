using Domain.Core.Base;
using Domain.Core.Rule;
using Menu.Domain.Common.Factories.Rules;
using Menu.Domain.Enums;

namespace Menu.Domain.ValueObjects
{
    public class FoodStatus : ValueObject
    {
        public FoodStatusEnum Value { get; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        private FoodStatus(FoodStatusEnum value)
        {
            Value = value;
        }

        public static FoodStatus Create(FoodStatusEnum value)
        {
            RuleValidator.CheckRules(new IBusinessRule[]
            {
                FoodStatusRuleFactory.FoodStatusValidate(value)
            });
            return new FoodStatus(value);
        }

        public static implicit operator FoodStatusEnum(FoodStatus foodStatus) => foodStatus.Value;

        public static implicit operator FoodStatus(FoodStatusEnum foodStatusEnum) => Create(foodStatusEnum);

        public override string ToString() => Value.ToString();
    }
}