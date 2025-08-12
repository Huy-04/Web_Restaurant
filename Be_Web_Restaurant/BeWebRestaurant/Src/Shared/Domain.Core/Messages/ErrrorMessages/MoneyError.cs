namespace Domain.Core.Messages.ErrrorMessages
{
    public static class MoneyError
    {
        // Amount
        public const string AmountMustNotBeNegative = "Amount must not be negative";

        // Factor
        public const string FactorMustNotBeNegative = "Multiply factor must not be negative.";

        // Currency
        public const string CurrencyMismatchError = "Cannot add money across different currencies";

        public const string InvalidCurrencyValue = "Invalid Currency value";
    }
}