using Inventory.Application.DTOs.Requests.FoodRecipe;
using Inventory.Domain.Entities;
using Inventory.Domain.ValueObjects.Common;

namespace Inventory.Application.Mapping.FoodRecipeMapExtension
{
    public static class RequestToFoodRecipe
    {
        public static FoodRecipe ToFoodRecipe(this FoodRecipeRequest request)
        {
            return FoodRecipe.Create(request.FoodId,
                request.IngredientsId,
                Quantity.Create(request.Quantity));
        }
    }
}