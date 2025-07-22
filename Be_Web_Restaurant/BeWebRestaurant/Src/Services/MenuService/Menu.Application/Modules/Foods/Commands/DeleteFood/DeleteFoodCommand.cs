using MediatR;

namespace Menu.Application.Modules.Foods.Commands.DeleteFood
{
    public sealed record DeleteFoodCommand(Guid IdFood) : IRequest<bool>
    {
    }
}