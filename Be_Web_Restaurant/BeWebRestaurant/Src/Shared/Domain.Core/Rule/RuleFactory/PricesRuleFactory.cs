using Domain.Core.Messages.ErrorMessages;
using Domain.Core.Messages.FiekdNames;
using Domain.Core.Rule.ListRule;
using Domain.Core.ValueObjects;

namespace Domain.Core.Rule.RuleFactory
{
    public static class PricesRuleFactory
    {
        public static IBusinessRule PricesNotEmpty(IEnumerable<Money> priceList)
        {
            return new ListNotEmpty<Money>(priceList, PricesField.Prices, PricesMessages.PricesMustNotBeEmpty); ;
        }

        public static IBusinessRule PricesUniqueCurrency(IEnumerable<Money> priceList, string property = "Currency")
        {
            return new IsUniqueProperty<Money>(priceList, PricesField.Prices, PricesMessages.PriceListUniqueCurrency, property);
        }
    }
}