using Domain.Core.Rule;
using Domain.Core.ValueObjects;
using Menu.Domain.Common.Factories.Rules;

namespace Menu.Domain.ValueObjects.Food
{
    public sealed class FoodName : Name
    {
        private FoodName(string value) : base(value)
        {
            RuleValidator.CheckRules(new IBusinessRule[]
            {
                FoodRuleFactory.NameMaxLength(value),
                FoodRuleFactory.NameNotEmpty(value)
            });
        }

        public static FoodName Create(string value)
        {
            return new FoodName(value);
        }
    }
}