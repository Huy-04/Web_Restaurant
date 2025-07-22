using MediatR;
using Menu.Application.DTOs.Responses.Food;

namespace Menu.Application.Modules.Foods.Queries.GetFoodById
{
    public sealed record GetFoodByIdQuery(Guid IdFood) : IRequest<FoodResponse>
    {
    }
}