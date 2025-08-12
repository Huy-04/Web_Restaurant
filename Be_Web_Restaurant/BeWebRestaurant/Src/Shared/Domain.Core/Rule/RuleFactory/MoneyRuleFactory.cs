using Domain.Core.Enums;
using Domain.Core.Messages;
using Domain.Core.Messages.ErrrorMessages;
using Domain.Core.Messages.FieldNames;
using Domain.Core.Rule.EnumRule;
using Domain.Core.Rule.NumberRule;

namespace Domain.Core.Rule.RuleFactory
{
    public static class MoneyRuleFactory
    {
        //factor
        public static IBusinessRule FactorNotNegative(decimal factor)
        {
            return new NotNegativeRule<decimal>(factor, MoneyField.Factor, MoneyError.FactorMustNotBeNegative);
        }

        // amount
        public static IBusinessRule AmountNotNegative(decimal amount)
        {
            return new NotNegativeRule<decimal>(amount, MoneyField.Amount, MoneyError.AmountMustNotBeNegative);
        }

        // Currency
        public static IBusinessRule CurrencyValidate(CurrencyEnum currency)
        {
            var validate = Enum.GetValues(typeof(CurrencyEnum)).Cast<CurrencyEnum>().ToList();
            return new EnumValidateRule<CurrencyEnum>(currency, validate, MoneyField.Currency, MoneyError.InvalidCurrencyValue);
        }

        public static IBusinessRule CurrencyEqual(CurrencyEnum left, CurrencyEnum right)
        {
            return new EnumEqualRule<CurrencyEnum>(left, right, MoneyField.Currency, MoneyError.CurrencyMismatchError);
        }
    }
}