using Domain.Core.Rule;
using Domain.Core.Rule.EnumRule;
using Domain.Core.Rule.NumberRule;
using Menu.Domain.Common.Message.ErroMessages;
using Menu.Domain.Common.Message.FieldNames;
using Menu.Domain.Enums;

namespace Menu.Domain.Common.Factories.Rules
{
    public static class MoneyRuleFactory
    {
        //factor
        public static IBusinessRule FactorNotNegative(decimal factor)
        {
            return new NotNegativeRule<decimal>(factor, MoneyField.Factor, MoneyMessages.FactorMustNotBeNegative);
        }

        // amount
        public static IBusinessRule AmountNotNegative(decimal amount)
        {
            return new NotNegativeRule<decimal>(amount, MoneyField.Amount, MoneyMessages.AmountMustNotBeNegative);
        }

        // Currency
        public static IBusinessRule CurrencyValidate(CurrencyEnum currency)
        {
            var validate = Enum.GetValues(typeof(CurrencyEnum)).Cast<CurrencyEnum>().ToList();
            return new EnumValidateRule<CurrencyEnum>(currency, validate, MoneyField.Currency, MoneyMessages.InvalidCurrencyValue);
        }

        public static IBusinessRule CurrencyEqual(CurrencyEnum left, CurrencyEnum right)
        {
            return new EnumEqualRule<CurrencyEnum>(left, right, MoneyField.Currency, MoneyMessages.CurrencyMismatchError);
        }
    }
}