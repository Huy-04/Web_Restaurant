namespace Menu.Domain.Common.Message
{
    public class ErrorMessages
    {
        // Food
        public const string FoodIdMustNotBeNegative = "Food ID must not be negative";
        public const string FoodNameMustNotBeEmpty = "Food name must not be empty";
        public const string FoodNameMaxLengthExceeded = "Food name must not exceed 50 characters";
        public const string DescriptionMaxLengthExceeded = "Food description must not exceed 255 characters";
        public const string ImgMaxLengthExceeded = "Food Img must not exceed 255 characters";
        public const string PriceMustNotBeNegative = "Price must not be negative";
        public const string CurrencyMismatchError = "Cannot add money across different currencies";
        public const string InvalidFoodStatusValue = "Invalid FoodStatus value";
        public const string InvalidCurrencyValue = "Invalid Currency value";
        public const string NotEnoughMoney = "Not enough money";

        // Other
        public const string FactorMustNotBeNegative = "Multiply factor must not be negative.";


        // FoodType
        public const string FoodTypeIdMustNotBeNegative = "Food type ID must not be negative";
        public const string FoodTypeNameMustNotBeEmpty = "Food type name must not be empty";
        public const string FoodTypeNameMaxLengthExceeded = "Food type name must not exceed 50 characters";
    }
}
