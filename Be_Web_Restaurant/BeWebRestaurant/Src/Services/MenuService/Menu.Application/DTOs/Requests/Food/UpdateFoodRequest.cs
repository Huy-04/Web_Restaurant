using Common.DTOs.Requests;
using Menu.Domain.Enums;

namespace Menu.Application.DTOs.Requests.Food
{
    public sealed record UpdateFoodRequest(
        string FoodName,
        Guid FoodTypeId,
        string Img,
        string Description,
        FoodStatusEnum FoodStatus,
        MoneyRequest Money)
    {
    }
}