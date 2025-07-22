using Menu.Application.DTOs.Requests.Food;
using Menu.Domain.Entities;
using Menu.Domain.ValueObjects;

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

        public static FoodName ToFoodName(this UpdateFoodRequest request)
        {
            return FoodName.Create(request.FoodName);
        }

        public static Description ToDescription(this UpdateFoodRequest request)
        {
            return Description.Create(request.Description);
        }

        public static Img ToImg(this UpdateFoodRequest request)
        {
            return Img.Create(request.Img);
        }

        public static FoodStatus ToFoodStatus(this UpdateFoodRequest request)
        {
            return FoodStatus.Create(request.Status);
        }

        public static PriceList ToPrices(this UpdateFoodRequest request)
        {
            return request.Prices.ToPrices();
        }

        public static void ApplyBasicInfo(this Food food, UpdateFoodRequest request)
        {
            food.UpdateBasic
               (request.ToFoodName(),
               request.ToImg(),
               request.ToDescription());
        }

        public static void ApplyStatus(this Food food, UpdateFoodRequest request)
        {
            food.UpdateStatus(request.ToFoodStatus());
        }

        public static void ApplyPrice(this Food food, UpdateFoodRequest request)
        {
            food.UpdatePrice(request.ToPrices());
        }

        public static void ApplyFoodTypeId(this Food food, UpdateFoodRequest request)
        {
            food.UpdateFoodTypeId(request.FoodTypeId);
        }
    }
}