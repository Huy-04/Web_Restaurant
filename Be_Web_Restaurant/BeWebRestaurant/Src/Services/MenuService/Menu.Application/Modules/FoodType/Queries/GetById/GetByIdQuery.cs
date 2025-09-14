using MediatR;
using Menu.Application.DTOs.Responses.FoodType;

namespace Menu.Application.Modules.FoodType.Queries.GetById
{
    public sealed record GetByIdQuery(Guid IdFoodType) : IRequest<FoodTypeResponse>
    {
    }
}