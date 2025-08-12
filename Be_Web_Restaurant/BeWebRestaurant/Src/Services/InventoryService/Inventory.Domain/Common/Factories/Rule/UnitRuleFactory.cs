using Domain.Core.Rule;
using Domain.Core.Rule.StringRule;
using Inventory.Domain.Common.Messages.ErrorMessages;
using Inventory.Domain.Common.Messages.FieldNames;

namespace Inventory.Domain.Common.Factories.Rule
{
    public static class UnitRuleFactory
    {
        public static IBusinessRule NameMaxLength(string name)
        {
            return new StringMaxLength(name, 50, UnitField.UnitName, UnitErrors.UnitNameMaxLengthExceeded);
        }

        public static IBusinessRule NameNotEmpty(string name)
        {
            return new StringNotEmpty(name, UnitField.UnitName, UnitErrors.UnitNameMustNotBeEmpty);
        }
    }
}