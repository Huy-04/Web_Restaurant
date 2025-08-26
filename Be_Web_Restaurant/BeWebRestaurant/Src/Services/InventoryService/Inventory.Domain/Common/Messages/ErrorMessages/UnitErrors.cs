namespace Inventory.Domain.Common.Messages.ErrorMessages
{
    public static class UnitErrors
    {
        public const string IdUitNotFound = "IdUnit Not Found";

        public const string UnitNameMustNotBeEmpty = "Unit name must not be empty";

        public const string UnitNameMaxLengthExceeded = "Unit name must not exceed 50 characters";

        public const string UnitNameExisted = "Unit name already exists";
    }
}