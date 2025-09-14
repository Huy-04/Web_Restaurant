using Inventory.Application.DTOs.Responses.FoodRecipe;
using MediatR;

namespace Inventory.Application.Modules.FoodRecipe.Queries.GetAll
{
    public sealed record GetAllQuery() : IRequest<IEnumerable<FoodRecipeResponse>>
    {
    }
}