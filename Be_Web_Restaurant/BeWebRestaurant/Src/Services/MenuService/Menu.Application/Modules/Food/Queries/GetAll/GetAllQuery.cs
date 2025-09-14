using MediatR;
using Menu.Application.DTOs.Responses.Food;

namespace Menu.Application.Modules.Food.Queries.GetAll
{
    public sealed record GetAllQuery() : IRequest<IEnumerable<FoodResponse>>
    {
    }
}