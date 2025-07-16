namespace Menu.Application.DTOs.Requests.Food
{
    public sealed record UpdateFoodBasicRequest(
        Guid IdFood,
        string FoodName,
        string Img,
        string Description)
    {
    }
}