namespace Inventory.Application.DTOs.Requests.FoodRecipe
{
    public sealed record FoodRecipeRequest(
        Guid FoodId,
        Guid IngredientsId,
        decimal Quantity
        )
    {
    }
}