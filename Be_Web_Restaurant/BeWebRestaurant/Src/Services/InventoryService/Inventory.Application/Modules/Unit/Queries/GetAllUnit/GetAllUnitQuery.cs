using Inventory.Application.DTOs.Responses.Unit;
using MediatR;

namespace Inventory.Application.Modules.Unit.Queries.GetAllUnit
{
    public sealed record GetAllUnitQuery() : IRequest<IEnumerable<UnitResponse>>
    {
    }
}