using Domain.Core.Rule;
using Domain.Core.ValueObjects;
using Inventory.Domain.Common.Factories.Rule;

namespace Inventory.Domain.ValueObjects.Ingredients
{
    public sealed class IngredientsName : Name
    {
        private IngredientsName(string value) : base(value)
        {
            RuleValidator.CheckRules(new IBusinessRule[]
            {
                IngredientsRuleFactory.NameMaxLength(value),
                IngredientsRuleFactory.NameNotEmpty(value)
            });
        }

        public IngredientsName Create(string value)
        {
            return new IngredientsName(value);
        }
    }
}