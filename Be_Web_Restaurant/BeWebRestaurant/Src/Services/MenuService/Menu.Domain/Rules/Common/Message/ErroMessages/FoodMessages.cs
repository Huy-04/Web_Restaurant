using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Domain.Rules.Common.Message.ErroMessages
{
    public static class FoodMessages
    {
        // FoodId
        public const string FoodIdMustNotBeNegative = "Food ID must not be negative";

        // FoodName
        public const string FoodNameMustNotBeEmpty = "Food name must not be empty";

        public const string FoodNameMaxLengthExceeded = "Food name must not exceed 50 characters";

        // Description
        public const string DescriptionMaxLengthExceeded = "Food description must not exceed 255 characters";

        public const string DescriptionNotBeEmpty = "Food description must not be empty";

        // Img
        public const string ImgMaxLengthExceeded = "Food Img must not exceed 255 characters";

        public const string ImgNotBeEmpty = "Food Img must not be empty";

        // Price
        public const string PriceMustNotBeNegative = "Price must not be negative";

        // Currency
        public const string CurrencyMismatchError = "Cannot add money across different currencies";

        public const string InvalidCurrencyValue = "Invalid Currency value";

        // FoodStatus
        public const string InvalidFoodStatusValue = "Invalid FoodStatus value";
    }
}