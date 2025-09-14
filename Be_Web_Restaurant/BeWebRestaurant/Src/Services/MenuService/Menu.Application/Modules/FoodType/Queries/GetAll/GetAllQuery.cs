using MediatR;
using Menu.Application.DTOs.Responses.FoodType;

namespace Menu.Application.Modules.FoodType.Queries.GetAll
{
    public sealed record GetAllQuery() : IRequest<IEnumerable<FoodTypeResponse>>
    {
    }
}