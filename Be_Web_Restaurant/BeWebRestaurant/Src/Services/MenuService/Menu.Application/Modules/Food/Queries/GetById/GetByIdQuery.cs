using MediatR;
using Menu.Application.DTOs.Responses.Food;

namespace Menu.Application.Modules.Food.Queries.GetById
{
    public sealed record GetByIdQuery(Guid IdFood) : IRequest<FoodResponse>
    {
    }
}