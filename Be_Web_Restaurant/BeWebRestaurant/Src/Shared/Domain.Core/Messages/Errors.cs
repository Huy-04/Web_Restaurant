namespace Domain.Core.Messages
{
    public static class Errors
    {
        // -----Money----- //

        // Amount
        public const string AmountMustNotBeNegative = "Amount must not be negative";

        // Factor
        public const string FactorMustNotBeNegative = "Multiply factor must not be negative.";

        // Currency
        public const string CurrencyMismatchError = "Cannot add money across different currencies";

        public const string InvalidCurrencyValue = "Invalid Currency value";

        // -----Money----- //

        // Prices
        public const string PricesMustNotBeEmpty = "Prices must not be empty";

        public const string PriceListUniqueCurrency = "Each currency must appear only once in price list";

        // Quantity
        public const string QuantityMustNotBeNegative = "Quantity must not be negative";

        // Description
        public const string DescriptionMaxLengthExceeded = "Description must not exceed 255 characters";

        public const string DescriptionNotBeEmpty = "Description must not be empty";

        // Img
        public const string ImgMaxLengthExceeded = "Img must not exceed 255 characters";

        public const string ImgNotBeEmpty = "Img must not be empty";
    }
}