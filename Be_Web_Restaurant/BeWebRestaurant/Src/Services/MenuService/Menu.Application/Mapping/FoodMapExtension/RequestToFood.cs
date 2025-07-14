using Menu.Application.DTOs.Requests.Food;
using Menu.Domain.Entities;
using Menu.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Application.Mapping.FoodMapExtension
{
    public static class RequestToFood
    {
        public static Money ToMoney(this MoneyRequest money)
        {
            return Money.Create(money.Amount, money.Currency);
        }

        public static PriceList ToPrices(this IReadOnlyCollection<MoneyRequest> prices)
        {
            return PriceList.Create(prices.Select(money => money.ToMoney()));
        }

        public static Food ToFood(CreateFoodRequest foodRequest)
        {
            return Food.Create(
                FoodName.Create(foodRequest.FoodName),
                foodRequest.Prices.ToPrices(),
                foodRequest.FoodTypeId,
                Img.Create(foodRequest.Img),
                Description.Create(foodRequest.Description));
        }
    }
}