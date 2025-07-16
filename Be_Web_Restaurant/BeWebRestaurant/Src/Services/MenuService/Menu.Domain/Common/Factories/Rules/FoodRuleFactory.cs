using Domain.Core.Rule;
using Domain.Core.Rule.StringRule;
using Menu.Domain.Common.Message.ErroMessages;
using Menu.Domain.Common.Message.FieldNames;

namespace Menu.Domain.Common.Factories.Rules
{
    public static class FoodRuleFactory
    {
        // FoodName
        public static IBusinessRule NameMaxLength(string value)
        {
            return new StringMaxLength(value, 50, FoodField.FoodName, FoodMessages.FoodNameMaxLengthExceeded);
        }

        public static IBusinessRule NameNotEmpty(string value)
        {
            return new StringNotEmpty(value, FoodField.FoodName, FoodMessages.FoodNameMustNotBeEmpty);
        }

        // Description
        public static IBusinessRule DescriptionMaxLength(string value)
        {
            return new StringMaxLength(value, 255, FoodField.Description, FoodMessages.DescriptionMaxLengthExceeded);
        }

        public static IBusinessRule DescriptionNotEmpty(string value)
        {
            return new StringNotEmpty(value, FoodField.Description, FoodMessages.DescriptionNotBeEmpty);
        }

        // Img
        public static IBusinessRule ImgMaxLength(string value)
        {
            return new StringMaxLength(value, 255, FoodField.Img, FoodMessages.ImgMaxLengthExceeded);
        }

        public static IBusinessRule ImgNotEmpty(string value)
        {
            return new StringNotEmpty(value, FoodField.Img, FoodMessages.ImgNotBeEmpty);
        }
    }
}