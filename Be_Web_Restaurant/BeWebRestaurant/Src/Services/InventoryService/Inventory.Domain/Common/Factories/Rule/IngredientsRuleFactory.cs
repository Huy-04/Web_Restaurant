using Domain.Core.Rule;
using Domain.Core.Rule.StringRule;
using Inventory.Domain.Common.Messages.ErrorMessages;
using Inventory.Domain.Common.Messages.FieldNames;

namespace Inventory.Domain.Common.Factories.Rule
{
    public static class IngredientsRuleFactory
    {
        public static IBusinessRule NameMaxLength(string name)
        {
            return new StringMaxLength(name, 50, IngredientsField.IngredientsName, IngredientsErrors.IngredientsNameMaxLengthExceeded);
        }

        public static IBusinessRule NameNotEmpty(string name)
        {
            return new StringNotEmpty(name, IngredientsField.IngredientsName, IngredientsErrors.IngredientsNameMustNotBeEmpty);
        }
    }
}