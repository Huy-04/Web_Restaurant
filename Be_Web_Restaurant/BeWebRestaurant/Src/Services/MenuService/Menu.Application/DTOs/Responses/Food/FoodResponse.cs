using Menu.Domain.Enums;

namespace Menu.Application.DTOs.Responses.Food
{
    public sealed record FoodResponse(
        Guid IdFood,
        string FoodName,
        string Img,
        String Description,
        FoodStatusEnum Status,
        Guid FoodTypeId,
        IReadOnlyCollection<MoneyRespose> Prices,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt)
    {
    }
}