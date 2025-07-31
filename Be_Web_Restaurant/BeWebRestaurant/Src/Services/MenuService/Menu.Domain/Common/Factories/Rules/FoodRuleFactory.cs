using Domain.Core.Rule;
using Domain.Core.Rule.EnumRule;
using Domain.Core.Rule.StringRule;
using Menu.Domain.Common.Messages.ErrorMessages;
using Menu.Domain.Common.Messages.FieldNames;
using Menu.Domain.Enums;

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

        // FoodStatus
        public static IBusinessRule FoodStatusValidate(FoodStatusEnum foodstatus)
        {
            var validate = Enum.GetValues(typeof(FoodStatusEnum)).Cast<FoodStatusEnum>().ToList();
            return new EnumValidateRule<FoodStatusEnum>(foodstatus, validate, FoodField.FoodStatus, FoodMessages.InvalidFoodStatusValue);
        }
    }
}