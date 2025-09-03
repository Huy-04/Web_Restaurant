using Inventory.Application.DTOs.Responses.Ingredients;
using MediatR;

namespace Inventory.Application.Modules.Ingredients.Queries.GetAllIngdients
{
    public sealed record GetAllIngredientsQuery() : IRequest<IEnumerable<IngredientsResponse>>
    {
    }
}