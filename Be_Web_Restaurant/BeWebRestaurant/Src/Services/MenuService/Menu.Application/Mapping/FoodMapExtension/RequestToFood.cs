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
        public static Money ToMoney(this MoneyRequest request)
        {
            return Money.Create(request.Amount, request.Currency);
        }

        public static PriceList ToPrices(this IReadOnlyCollection<MoneyRequest> request)
        {
            return PriceList.Create(request.Select(money => money.ToMoney()));
        }

        public static Food ToFood(this CreateFoodRequest request)
        {
            return Food.Create(
                FoodName.Create(request.FoodName),
                request.Prices.ToPrices(),
                request.FoodTypeId,
                Img.Create(request.Img),
                Description.Create(request.Description));
        }

        public static FoodName ToFoodName(this UpdateFoodBasicRequest request)
        {
            return FoodName.Create(request.FoodName);
        }

        public static Description ToDescription(this UpdateFoodBasicRequest request)
        {
            return Description.Create(request.Description);
        }

        public static Img ToImg(this UpdateFoodBasicRequest request)
        {
            return Img.Create(request.Img);
        }

        public static FoodStatus ToFoodStatus(this UpdateFoodStatusRequest request)
        {
            return FoodStatus.Create(request.FoodStatus);
        }

        public static PriceList ToPrices(this UpdatePricesRequest request)
        {
            return request.Prices.ToPrices();
        }

        public static void ApplyBasicInfo(this Food food, UpdateFoodBasicRequest request)
        {
            food.UpdateBasic
               (request.ToFoodName(),
               request.ToImg(),
               request.ToDescription());
        }

        public static void ApplyStatus(this Food food, UpdateFoodStatusRequest request)
        {
            food.UpdateStatus(request.ToFoodStatus());
        }

        public static void ApplyPrice(this Food food, UpdatePricesRequest request)
        {
            food.UpdatePrice(request.ToPrices());
        }

        public static void ApplyFoodTypeId(this Food food, UpdateFoodTypeIdRequest request)
        {
            food.UpdateFoodTypeId(request.FoodTypeId);
        }
    }
}