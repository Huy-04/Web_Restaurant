using Domain.Core.Rule;
using Domain.Core.ValueObjects;
using Menu.Domain.Common.Factories.Rules;

namespace Menu.Domain.ValueObjects.FoodType
{
    public sealed class FoodTypeName : Name
    {
        private FoodTypeName(string value) : base(value)
        {
            RuleValidator.CheckRules(new IBusinessRule[]
            {
                FoodTypeRuleFactory.NameMaxLength(value),
                FoodTypeRuleFactory.NameNotEmpty(value)
            });
        }

        public static FoodTypeName Create(string value)
        {
            return new FoodTypeName(value);
        }
    }
}