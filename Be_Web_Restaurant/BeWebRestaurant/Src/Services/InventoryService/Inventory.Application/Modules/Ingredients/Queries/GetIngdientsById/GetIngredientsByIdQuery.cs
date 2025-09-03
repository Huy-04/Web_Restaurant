using Inventory.Application.DTOs.Responses.Ingredients;
using Inventory.Application.Interfaces;
using MediatR;

namespace Inventory.Application.Modules.Ingredients.Queries.GetIngdientsById
{
    public sealed record GetIngredientsByIdQuery(Guid IdIngredients) : IRequest<IngredientsResponse>
    {
    }
}