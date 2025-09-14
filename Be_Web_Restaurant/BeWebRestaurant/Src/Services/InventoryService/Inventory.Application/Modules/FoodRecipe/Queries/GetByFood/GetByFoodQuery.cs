using Inventory.Application.DTOs.Responses.FoodRecipe;
using MediatR;

namespace Inventory.Application.Modules.FoodRecipe.Queries.GetByFood
{
    public sealed record GetByFoodQuery(Guid FoodId) : IRequest<IEnumerable<FoodRecipeResponse>>
    {
    }
}