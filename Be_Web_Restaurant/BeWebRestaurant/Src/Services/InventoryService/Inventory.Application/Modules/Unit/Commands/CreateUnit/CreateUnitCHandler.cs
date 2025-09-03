using Domain.Core.Enums;
using Domain.Core.Messages.FieldNames;
using Domain.Core.Rule;
using Domain.Core.Rule.RuleFactory;
using Inventory.Application.DTOs.Responses.Unit;
using Inventory.Application.Interfaces;
using Inventory.Application.Mapping.UnitMapExtension;
using Inventory.Domain.Common.Messages.FieldNames;
using Inventory.Domain.ValueObjects.Unit;
using MediatR;

namespace Inventory.Application.Modules.Unit.Commands.CreateUnit
{
    public sealed class CreateUnitCHandler : IRequestHandler<CreateUnitCommand, UnitResponse>
    {
        private IUnitOfWork _uow;

        public CreateUnitCHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<UnitResponse> Handle(CreateUnitCommand cm, CancellationToken token)
        {
            await _uow.BeginTransactionAsync(token);
            try
            {
                var newName = UnitName.Create(cm.Request.UnitName);
                if (await _uow.UnitRepo.ExistsByNameAsync(newName))
                {
                    throw RuleFactory.SimpleRuleException
                        (ErrorCategory.Conflict,
                        UnitField.UnitName,
                        ErrorCode.NameAlreadyExists,
                        new Dictionary<string, object>
                        {
                            {ParamField.Value,newName.Value }
                        });
                }
                var entity = cm.Request.ToUnit();
                await _uow.UnitRepo.CreateAsync(entity);
                await _uow.CommitAsync(token);
                return entity.ToUnitToResponse();
            }
            catch
            {
                await _uow.RollBackAsync(token);
                throw;
            }
        }
    }
}