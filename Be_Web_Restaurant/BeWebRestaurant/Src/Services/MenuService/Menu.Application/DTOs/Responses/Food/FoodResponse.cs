using Menu.Domain.Enums;

namespace Menu.Application.DTOs.Responses.Food
{
    public sealed record FoodResponse(
        Guid IdFood,
        string FoodName,
        string Img,
        string Description,
        FoodStatusEnum FoodStatus,
        Guid FoodTypeId,
        string FoodTypeName,
        IReadOnlyCollection<MoneyResponse> Prices,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt)
    {
    }
}