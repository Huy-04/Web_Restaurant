using Common.DTOs.Responses;
using Domain.Core.ValueObjects;

namespace Common.Mapping.PriceMapExtemsion
{
    public static class PricesToResponse
    {
        public static MoneyResponse ToMoneyResponse(this Money money)
        {
            return new(money.Amount, money.Currency);
        }

        public static IReadOnlyCollection<MoneyResponse> ToPrices(this IEnumerable<Money> prices)
        {
            return prices.Select(money => money.ToMoneyResponse()).ToList().AsReadOnly();
        }
    }
}