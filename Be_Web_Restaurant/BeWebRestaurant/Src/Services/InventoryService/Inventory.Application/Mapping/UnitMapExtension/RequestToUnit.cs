using Inventory.Application.DTOs.Requests.Unit;
using Inventory.Domain.Entities;
using Inventory.Domain.ValueObjects.Unit;

namespace Inventory.Application.Mapping.UnitMapExtension
{
    public static class RequestToUnit
    {
        public static Unit ToUnit(this UnitRequest request)
        {
            return Unit.Create(UnitName.Create(request.UnitName));
        }

        public static UnitName ToUnitName(this UnitRequest request)
        {
            return UnitName.Create(request.UnitName);
        }
    }
}