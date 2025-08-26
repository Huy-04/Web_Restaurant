using Domain.Core.Rule;
using Inventory.Application.DTOs.Requests.Unit;
using Inventory.Application.DTOs.Responses.Unit;
using Inventory.Domain.Common.Factories.Rule;
using MediatR;

namespace Inventory.Application.Modules.Unit.Commands.CreateUnit
{
    public sealed record CreateUnitCommand(UnitRequest Request) : IRequest<UnitResponse>, IValidateRequest
    {
        public IEnumerable<IBusinessRule> GetRule()
        {
            yield return UnitRuleFactory.NameMaxLength(Request.UnitName);
            yield return UnitRuleFactory.NameNotEmpty(Request.UnitName);
        }
    }
}