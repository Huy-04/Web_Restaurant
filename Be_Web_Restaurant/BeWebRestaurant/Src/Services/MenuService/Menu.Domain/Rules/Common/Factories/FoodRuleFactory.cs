using Domain.Core.Rule;
using Domain.Core.Rule.Common;
using Domain.Core.Rule.Common.EnumRule;
using Domain.Core.Rule.Common.StringRule;
using Menu.Domain.Enums;
using Menu.Domain.Rules.Common.Message.ErroMessages;
using Menu.Domain.Rules.Common.Message.FieldNames;

namespace Menu.Domain.Rules.Common.Factories
{
    public static class FoodRuleFactory
    {
        // FoodName
        public static IBusinessRule NameMaxLength(string value)
        {
            return new StringMaxLength(value, 50, FoodField.NameFood, FoodMessages.FoodNameMaxLengthExceeded);
        }

        public static IBusinessRule NameNotEmpty(string value)
        {
            return new StringNotEmpty(value, FoodField.NameFood, FoodMessages.FoodNameMustNotBeEmpty);
        }

        // Description
        public static IBusinessRule DescriptionMaxLength(string value)
        {
            return new StringMaxLength(value, 255, FoodField.Description, FoodMessages.DescriptionMaxLengthExceeded);
        }

        public static IBusinessRule DescriptionNotEmpty(string value)
        {
            return new StringNotEmpty(value, FoodField.Description, FoodMessages.DescriptionMaxLengthExceeded);
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

        // Currency
        public static IBusinessRule CurrencyValidate(CurrencyEnum currency)
        {
            var validate = Enum.GetValues(typeof(CurrencyEnum)).Cast<CurrencyEnum>().ToList();
            return new EnumValidateRule<CurrencyEnum>(currency, validate, FoodField.Currency, FoodMessages.InvalidCurrencyValue);
        }

        public static IBusinessRule CurrencyEqual(CurrencyEnum left, CurrencyEnum right)
        {
            return new EnumEqualRule<CurrencyEnum>(left, right, FoodField.Currency, FoodMessages.CurrencyMismatchError);
        }

        // FoodStatus
        public static IBusinessRule FoodStatusValidate(FoodStatusEnum foodstatus)
        {
            var validate = Enum.GetValues(typeof(FoodStatusEnum)).Cast<FoodStatusEnum>().ToList();
            return new EnumValidateRule<FoodStatusEnum>(foodstatus, validate, FoodField.FoodStatus, FoodMessages.InvalidFoodStatusValue);
        }

        // Price
        public static IBusinessRule PriceNotNegative(decimal price)
        {
            return new NotNegativeRule<decimal>(price, FoodField.Price, FoodMessages.PriceMustNotBeNegative);
        }
    }
}