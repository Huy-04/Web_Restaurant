using Domain.Core.Messages;
using Domain.Core.Rule.StringRule;

namespace Domain.Core.Rule.RuleFactory
{
    public static class ImgRuleFactory
    {
        public static IBusinessRule ImgMaxLength(string value)
        {
            return new StringMaxLength(value, 255, FieldNames.Img, Errors.ImgMaxLengthExceeded);
        }

        public static IBusinessRule ImgNotEmpty(string value)
        {
            return new StringNotEmpty(value, FieldNames.Img, Errors.ImgNotBeEmpty);
        }
    }
}