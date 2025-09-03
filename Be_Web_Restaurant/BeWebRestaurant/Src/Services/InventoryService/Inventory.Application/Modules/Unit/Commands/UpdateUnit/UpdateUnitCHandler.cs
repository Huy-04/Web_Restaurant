using Domain.Core.Enums;
using Domain.Core.Messages.FieldNames;
using Domain.Core.Rule.RuleFactory;
using Inventory.Application.DTOs.Responses.Unit;
using Inventory.Application.Interfaces;
using Inventory.Application.Mapping.UnitMapExtension;
using Inventory.Domain.Common.Messages.FieldNames;
using MediatR;

namespace Inventory.Application.Modules.Unit.Commands.UpdateUnit
{
    public sealed class UpdateUnitCHandler : IRequestHandler<UpdateUnitCommand, UnitResponse>
    {
        private readonly IUnitOfWork _uow;

        public UpdateUnitCHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<UnitResponse> Handle(UpdateUnitCommand cm, CancellationToken token)
        {
            await _uow.BeginTransactionAsync(token);

            try
            {
                var repo = _uow.UnitRepo;

                var entity = await repo.GetByIdAsync(cm.IdUnit);
                if (entity is null)
                {
                    throw RuleFactory.SimpleRuleException
                        (ErrorCategory.NotFound,
                        UnitField.IdUnit,
                        ErrorCode.IdNotFound,
                        new Dictionary<string, object>
                        {
                            {ParamField.Value,cm.IdUnit }
                        });
                }
                var newName = cm.Request.ToUnitName();
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
                entity.Update(newName);
                await _uow.UnitRepo.UpdateAsync(entity);
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