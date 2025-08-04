using Domain.Core.Messages;
using Domain.Core.Rule.StringRule;

namespace Domain.Core.Rule.RuleFactory
{
    public static class DescriptionRuleFactory
    {
        public static IBusinessRule DescriptionMaxLength(string value)
        {
            return new StringMaxLength(value, 255, FieldNames.Description, Errors.DescriptionMaxLengthExceeded);
        }

        public static IBusinessRule DescriptionNotEmpty(string value)
        {
            return new StringNotEmpty(value, FieldNames.Description, Errors.DescriptionNotBeEmpty);
        }
    }
}