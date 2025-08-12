namespace Inventory.Application.DTOs.Responses.FoodRecipe
{
    public sealed record FoodRecipeResponse(
        Guid IdFoodRecipe,
        Guid FoodId,
        Guid IngredientsId,
        decimal Quantity,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt
        )
    {
    }
}