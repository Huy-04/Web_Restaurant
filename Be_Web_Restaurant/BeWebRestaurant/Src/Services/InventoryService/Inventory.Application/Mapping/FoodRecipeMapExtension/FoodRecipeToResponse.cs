using Inventory.Application.DTOs.Responses.FoodRecipe;
using Inventory.Domain.Entities;

namespace Inventory.Application.Mapping.FoodRecipeMapExtension
{
    public static class FoodRecipeToResponse
    {
        public static FoodRecipeResponse ToFoodRecipeResponse(this FoodRecipe foodRecipe)
        {
            return new(foodRecipe.Id,
                foodRecipe.FoodId,
                foodRecipe.IngredientsId,
                foodRecipe.Quantity,
                foodRecipe.CreatedAt,
                foodRecipe.UpdatedAt);
        }
    }
}