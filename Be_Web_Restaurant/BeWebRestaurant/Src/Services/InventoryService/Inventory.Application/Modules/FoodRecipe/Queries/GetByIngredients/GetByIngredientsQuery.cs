using Inventory.Application.DTOs.Responses.FoodRecipe;
using MediatR;

namespace Inventory.Application.Modules.FoodRecipe.Queries.GetByIngredients
{
    public sealed record GetByIngredientsQuery(Guid IngredientsId) : IRequest<IEnumerable<FoodRecipeResponse>>
    {
    }
}