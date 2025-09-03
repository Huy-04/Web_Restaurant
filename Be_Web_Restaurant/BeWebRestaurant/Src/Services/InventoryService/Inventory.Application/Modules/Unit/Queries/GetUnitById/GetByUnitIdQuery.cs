using Inventory.Application.DTOs.Responses.Unit;
using MediatR;

namespace Inventory.Application.Modules.Unit.Queries.GetUnitById
{
    public sealed record GetByUnitIdQuery(Guid IdUnit) : IRequest<UnitResponse>
    {
    }
}