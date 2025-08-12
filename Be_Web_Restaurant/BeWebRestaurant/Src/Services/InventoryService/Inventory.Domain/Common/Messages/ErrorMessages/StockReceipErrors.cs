namespace Inventory.Domain.Common.Messages.ErrorMessages
{
    public static class StockReceipErrors
    {
        public const string SupplierMustNotBeEmpty = "Supplier must not be empty";

        public const string SupplierMaxLengthExceeded = "Supplier must not exceed 50 characters";
    }
}