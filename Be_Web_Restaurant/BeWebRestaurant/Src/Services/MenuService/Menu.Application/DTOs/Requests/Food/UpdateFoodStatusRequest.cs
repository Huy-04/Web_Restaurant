using Menu.Domain.Enums;

namespace Menu.Application.DTOs.Requests.Food
{
    public sealed record UpdateFoodStatusRequest(Guid FoodId, FoodStatusEnum FoodStatus)
    {
    }
}