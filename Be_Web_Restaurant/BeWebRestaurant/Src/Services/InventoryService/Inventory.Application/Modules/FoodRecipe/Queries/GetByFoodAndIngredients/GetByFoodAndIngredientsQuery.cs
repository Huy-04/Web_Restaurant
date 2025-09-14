using Inventory.Application.DTOs.Responses.FoodRecipe;
using MediatR;

namespace Inventory.Application.Modules.FoodRecipe.Queries.GetByFoodAndIngredients
{
    public sealed record GetByFoodAndIngredientsQuery(Guid IngredientsId, Guid FoodId) : IRequest<IEnumerable<FoodRecipeResponse>>
    {
    }
}