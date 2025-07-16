using MediatR;
using Menu.Application.DTOs.Requests.FoodType;
using Menu.Application.DTOs.Responses.FoodType;

namespace Menu.Application.Modules.FoodTypes.Commands.UpdateFoodType
{
    public sealed record UpdateFoodTypeCommand(UpdateFoodTypeRequest Request)
        : IRequest<FoodTypeResponse>
    { }
}