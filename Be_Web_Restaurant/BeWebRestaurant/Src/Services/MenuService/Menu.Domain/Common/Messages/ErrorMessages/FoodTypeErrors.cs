namespace Menu.Domain.Common.Messages.ErrorMessages
{
    public static class FoodTypeErrors
    {
        // IdFoodType
        public const string IdFoodTypeNotFound = "IdFoodType Not Found";

        // FoodTypeName
        public const string FoodTypeNameMustNotBeEmpty = "Food type name must not be empty";

        public const string FoodTypeNameMaxLengthExceeded = "Food type name must not exceed 50 characters";

        public const string FoodTypeNameexisted = "Food type name already exists";
    }
}