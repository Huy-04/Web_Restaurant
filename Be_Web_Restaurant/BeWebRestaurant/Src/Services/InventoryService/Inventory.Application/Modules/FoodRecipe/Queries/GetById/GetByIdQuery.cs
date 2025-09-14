using Inventory.Application.DTOs.Responses.FoodRecipe;
using MediatR;

namespace Inventory.Application.Modules.FoodRecipe.Queries.GetById
{
    public sealed record GetByIdQuery(Guid IdFoodRecipe) : IRequest<FoodRecipeResponse>
    {
    }
}