namespace Menu.Application.DTOs.Requests.Food
{
    public sealed record UpdateFoodTypeIdRequest(Guid IdFood, Guid FoodTypeId)
    {
    }
}