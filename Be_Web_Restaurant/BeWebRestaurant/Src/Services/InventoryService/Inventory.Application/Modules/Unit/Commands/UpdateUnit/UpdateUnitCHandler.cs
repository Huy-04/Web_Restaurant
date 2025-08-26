using Domain.Core.Enums;
using Domain.Core.Rule.RuleFactory;
using Inventory.Application.DTOs.Responses.Unit;
using Inventory.Application.Interfaces;
using Inventory.Application.Mapping.UnitMapExtension;
using Inventory.Domain.Common.Messages.ErrorMessages;
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
                    throw RuleFactory.SimpleRuleException(ErrorCode.NotFound, UnitField.IdUnit, new[] { UnitErrors.IdUitNotFound });
                }
                var newName = cm.Request.ToUnitName();
                if (await _uow.UnitRepo.ExistsByNameAsync(newName))
                {
                    throw RuleFactory.SimpleRuleException(ErrorCode.Conflict, UnitField.UnitName, new[] { UnitErrors.UnitNameExisted });
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