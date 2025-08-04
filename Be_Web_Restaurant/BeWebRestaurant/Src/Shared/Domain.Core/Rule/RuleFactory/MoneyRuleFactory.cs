using Domain.Core.Enums;
using Domain.Core.Messages;
using Domain.Core.Rule.EnumRule;
using Domain.Core.Rule.NumberRule;

namespace Domain.Core.Rule.RuleFactory
{
    public static class MoneyRuleFactory
    {
        //factor
        public static IBusinessRule FactorNotNegative(decimal factor)
        {
            return new NotNegativeRule<decimal>(factor, FieldNames.Factor, Errors.FactorMustNotBeNegative);
        }

        // amount
        public static IBusinessRule AmountNotNegative(decimal amount)
        {
            return new NotNegativeRule<decimal>(amount, FieldNames.Amount, Errors.AmountMustNotBeNegative);
        }

        // Currency
        public static IBusinessRule CurrencyValidate(CurrencyEnum currency)
        {
            var validate = Enum.GetValues(typeof(CurrencyEnum)).Cast<CurrencyEnum>().ToList();
            return new EnumValidateRule<CurrencyEnum>(currency, validate, FieldNames.Currency, Errors.InvalidCurrencyValue);
        }

        public static IBusinessRule CurrencyEqual(CurrencyEnum left, CurrencyEnum right)
        {
            return new EnumEqualRule<CurrencyEnum>(left, right, FieldNames.Currency, Errors.CurrencyMismatchError);
        }
    }
}