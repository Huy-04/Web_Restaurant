using MediatR;

namespace Inventory.Application.Modules.Unit.Commands.DeleteUnit
{
    public sealed record DeleteUnitCommand(Guid IdUnit) : IRequest<bool>
    {
    }
}