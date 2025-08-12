namespace Inventory.Domain.Common.Messages.ErrorMessages
{
    public static class IngredientsErrors
    {
        public const string IngredientsNameMustNotBeEmpty = "Ingredients name must not be empty";

        public const string IngredientsNameMaxLengthExceeded = "Ingredients name must not exceed 50 characters";
    }
}