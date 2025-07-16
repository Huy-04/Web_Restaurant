using Domain.Core.Rule;
using Menu.Domain.Common.Message.ErroMessages;
using Menu.Domain.Common.Message.FieldNames;
using Domain.Core.Rule.ListRule;
using Menu.Domain.ValueObjects;

namespace Menu.Domain.Common.Factories.Rules
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