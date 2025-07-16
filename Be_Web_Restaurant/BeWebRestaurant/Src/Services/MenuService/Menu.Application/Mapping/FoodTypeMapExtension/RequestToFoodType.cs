using Menu.Application.DTOs.Requests.FoodType;
using Menu.Domain.Entities;
using Menu.Domain.ValueObjects;

namespace Menu.Application.Mapping.FoodTypeMapExtension
{
    public static class RequestToFoodType
    {
        public static FoodType ToFoodType(this CreateFoodTypeRequest request)
        {
            return FoodType.Create(FoodTypeName.Create(request.FoodTypeName));
        }

        public static FoodTypeName ToFoodTypeName(this UpdateFoodTypeRequest request)
        {
            return FoodTypeName.Create(request.FoodTypeName);
        }

        public static void ApplyFoodType(this FoodType foodType, UpdateFoodTypeRequest request)
        {
            foodType.UpdateName(request.ToFoodTypeName());
        }
    }
}