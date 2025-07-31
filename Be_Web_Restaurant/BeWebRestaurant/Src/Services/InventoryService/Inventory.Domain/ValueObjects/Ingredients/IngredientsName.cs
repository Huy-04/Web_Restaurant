using Domain.Core.Base;
using Domain.Core.Rule;
using Inventory.Domain.Common.Factories.Rule;

namespace Inventory.Domain.ValueObjects.Ingredients
{
    public sealed class IngredientsName : ValueObject
    {
        public string Value { get; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        private IngredientsName(string value)
        {
            Value = value;
        }

        public IngredientsName Create(string value)
        {
            RuleValidator.CheckRules(new IBusinessRule[]
            {
                IngredientsRuleFactory.NameMaxLength(value),
                IngredientsRuleFactory.NameNotEmpty(value)
            });
            return new IngredientsName(value);
        }

        public static implicit operator string(IngredientsName ingredientsName) => ingredientsName.Value;

        public override string ToString() => Value;
    }
}