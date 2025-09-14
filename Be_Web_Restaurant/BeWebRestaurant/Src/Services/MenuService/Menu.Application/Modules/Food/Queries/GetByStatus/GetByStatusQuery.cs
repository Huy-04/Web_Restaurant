using MediatR;
using Menu.Application.DTOs.Responses.Food;
using Menu.Domain.ValueObjects.Food;

namespace Menu.Application.Modules.Food.Queries.GetByStatus
{
    public sealed record GetByStatusQuery(FoodStatus foodStatus) : IRequest<IEnumerable<FoodResponse>>
    {
    }
}