using MediatR;
using Menu.Application.DTOs.Responses.FoodType;

namespace Menu.Application.Modules.FoodTypes.Queries.GetAllFoodType
{
    public sealed record GetAllFoodTypesQuery() : IRequest<IEnumerable<FoodTypeResponse>>
    {
    }
}