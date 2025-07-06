namespace Menu.Domain.Common.Message.ErroMessages
{
    public static class MoneyMessages
    {
        public const string AmountMustNotBeNegative = "Amount must not be negative";

        public const string FactorMustNotBeNegative = "Multiply factor must not be negative.";

        // Currency
        public const string CurrencyMismatchError = "Cannot add money across different currencies";

        public const string InvalidCurrencyValue = "Invalid Currency value";
    }
}