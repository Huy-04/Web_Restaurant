namespace Menu.Domain.Common.Messages.ErrorMessages
{
    public static class FoodMessages
    {
        // IdFood
        public const string IdFoodNotFound = "IdFood Not Found";

        // FoodName
        public const string FoodNameMustNotBeEmpty = "Food name must not be empty";

        public const string FoodNameMaxLengthExceeded = "Food name must not exceed 50 characters";

        public const string FoodNameexisted = "Food name already exists";

        // Status
        public const string InvalidFoodStatusValue = "Invalid Food Status value";
    }
}