using Domain.Core.Enums;
using Domain.Core.Messages.FieldNames;
using Domain.Core.Rule.RuleFactory;
using Inventory.Application.DTOs.Responses.Unit;
using Inventory.Application.Interfaces;
using Inventory.Application.Mapping.UnitMapExtension;
using Inventory.Domain.Common.Messages.FieldNames;
using MediatR;

namespace Inventory.Application.Modules.Unit.Queries.GetUnitById
{
    public sealed class GetByUnitIdQHandler : IRequestHandler<GetByUnitIdQuery, UnitResponse>
    {
        private readonly IUnitOfWork _uow;

        public GetByUnitIdQHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<UnitResponse> Handle(GetByUnitIdQuery query, CancellationToken token)
        {
            var entity = await _uow.UnitRepo.GetByIdAsync(query.IdUnit);
            if (entity is null)
            {
                throw RuleFactory.SimpleRuleException(
                    ErrorCategory.NotFound,
                    UnitField.IdUnit,
                    ErrorCode.IdNotFound,
                    new Dictionary<string, object>
                    {
                        {ParamField.Value,query.IdUnit }
                    });
            }
            return entity.ToUnitToResponse();
        }
    }
}