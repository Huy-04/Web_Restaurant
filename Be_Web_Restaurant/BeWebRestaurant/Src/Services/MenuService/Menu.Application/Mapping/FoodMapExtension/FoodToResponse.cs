using Menu.Application.DTOs.Responses.Food;
using Menu.Domain.Entities;
using Menu.Domain.ValueObjects;

namespace Menu.Application.Mapping.FoodMapExtension
{
    public static class FoodToResponse
    {
        public static MoneyRespose ToMoneyResponse(this Money money)
        {
            return new(money.Amount, money.Currency);
        }

        public static IReadOnlyCollection<MoneyRespose> ToPrices(this IEnumerable<Money> prices)
        {
            return prices.Select(money => money.ToMoneyResponse()).ToList().AsReadOnly();
        }

        public static FoodResponse ToFoodResponse(this Food food)
        {
            return new(
                food.Id,
                food.FoodName.Value,
                food.Img.Value,
                food.Description.Value,
                food.FoodStatus.Value,
                food.FoodTypeId,
                food.Prices.Items.ToPrices(),
                food.CreatedAt,
                food.UpdatedAt);
        }
    }
}