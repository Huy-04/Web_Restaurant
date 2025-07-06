using Domain.Core.Rule;
using Menu.Domain.Common.Message.ErroMessages;
using Menu.Domain.Common.Message.FieldNames;
using Domain.Core.Rule.ListRule;

namespace Menu.Domain.Common.Factories.Rules
{
    public static class PricesRuleFactory
    {
        public static IBusinessRule PricesNotEmpty(IEnumerable<ValueObjects.Money> priceList)
        {
            return new ListNotEmpty<ValueObjects.Money>(priceList, PricesField.Prices, PricesMessages.PricesMustNotBeEmpty); ;
        }

        public static IBusinessRule PricesUniqueCurrency(IEnumerable<ValueObjects.Money> priceList, string property = "Currency")
        {
            return new IsUniqueProperty<ValueObjects.Money>(priceList, PricesField.Prices, PricesMessages.PriceListUniqueCurrency, property);
        }
    }
}