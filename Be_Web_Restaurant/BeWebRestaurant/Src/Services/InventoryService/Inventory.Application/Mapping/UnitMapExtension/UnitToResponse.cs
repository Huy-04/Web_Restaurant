using Inventory.Application.DTOs.Responses.Unit;
using Inventory.Domain.Entities;
using System.Runtime.CompilerServices;

namespace Inventory.Application.Mapping.UnitMapExtension
{
    public static class UnitToResponse
    {
        public static UnitResponse ToUnitToResponse(this Unit unit)
        {
            return new(unit.Id,
                unit.UnitName,
                unit.CreatedAt,
                unit.UpdatedAt);
        }
    }
}