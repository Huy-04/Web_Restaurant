using MediatR;
using Menu.Application.DTOs.Responses.Food;

namespace Menu.Application.Modules.Foods.Queries.GetAllFoods
{
    public sealed record GetAllFoodsQuery() : IRequest<IEnumerable<FoodResponse>>
    {
    }
}