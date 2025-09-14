using Inventory.Application.DTOs.Responses.FoodRecipe;
using Inventory.Domain.Entities;

namespace Inventory.Application.Mapping.FoodRecipeMapExtension
{
    public static class FoodRecipeToResponse
    {
        public static FoodRecipeResponse ToFoodRecipeResponse(this FoodRecipe foodRecipe, string ingredientsName)
        {
            return new(foodRecipe.Id,
                foodRecipe.FoodId,
                foodRecipe.IngredientsId,
                ingredientsName,
                foodRecipe.Quantity,
                foodRecipe.CreatedAt,
                foodRecipe.UpdatedAt);
        }
    }
}