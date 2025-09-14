using MediatR;
using Menu.Application.DTOs.Responses.Food;

namespace Menu.Application.Modules.Food.Queries.GetByFoodType
{
    public sealed record GetByFoodTypeQuery(Guid FoodTypeId) : IRequest<IEnumerable<FoodResponse>>
    {
    }
}