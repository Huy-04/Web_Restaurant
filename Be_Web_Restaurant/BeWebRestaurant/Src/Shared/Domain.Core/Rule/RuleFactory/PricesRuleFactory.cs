using Domain.Core.Messages;
using Domain.Core.Rule.ListRule;
using Domain.Core.ValueObjects;

namespace Domain.Core.Rule.RuleFactory
{
    public static class PricesRuleFactory
    {
        public static IBusinessRule PricesNotEmpty(IEnumerable<Money> priceList)
        {
            return new ListNotEmpty<Money>(priceList, FieldNames.Prices, Errors.PricesMustNotBeEmpty); ;
        }

        public static IBusinessRule PricesUniqueCurrency(IEnumerable<Money> priceList, string property = "Currency")
        {
            return new IsUniqueProperty<Money>(priceList, FieldNames.Prices, Errors.PriceListUniqueCurrency, property);
        }
    }
}