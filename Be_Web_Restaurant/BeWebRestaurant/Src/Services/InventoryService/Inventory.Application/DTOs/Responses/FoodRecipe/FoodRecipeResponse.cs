namespace Inventory.Application.DTOs.Responses.FoodRecipe
{
    public sealed record FoodRecipeResponse(
        Guid IdFoodRecipe,
        Guid FoodId,
        string foodName,
        Guid IngredientsId,
        string ingredientsName,
        decimal Quantity,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt
        )
    {
    }
}