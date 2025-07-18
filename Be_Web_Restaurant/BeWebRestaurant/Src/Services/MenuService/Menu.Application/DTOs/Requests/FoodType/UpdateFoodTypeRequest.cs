namespace Menu.Application.DTOs.Requests.FoodType
{
    public sealed record UpdateFoodTypeRequest(Guid IdFoodType, string FoodTypeName)
    {
    }
}