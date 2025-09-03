using Domain.Core.Enums;
using Domain.Core.Messages.FieldNames;
using Domain.Core.Rule.RuleFactory;
using MediatR;
using Menu.Application.DTOs.Responses.FoodType;
using Menu.Application.Interfaces;
using Menu.Application.Mapping.FoodTypeMapExtension;
using Menu.Domain.Common.Messages.FieldNames;

namespace Menu.Application.Modules.FoodTypes.Commands.UpdateFoodType
{
    public sealed class UpdateFoodTypeCHandler : IRequestHandler<UpdateFoodTypeCommand, FoodTypeResponse>
    {
        private readonly IUnitOfWork _uow;

        public UpdateFoodTypeCHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<FoodTypeResponse> Handle(UpdateFoodTypeCommand cm, CancellationToken token)
        {
            await _uow.BeginTransactionAsync(token);

            try
            {
                var repo = _uow.FoodTypeRepo;
                var entity = await repo.GetByIdAsync(cm.IdFoodType);
                if (entity is null)
                {
                    throw RuleFactory.SimpleRuleException
                        (ErrorCategory.NotFound,
                        FoodTypeField.IdFoodType,
                        ErrorCode.IdNotFound,
                        new Dictionary<string, object>
                        {
                            {ParamField.Value,cm.IdFoodType }
                        });
                }
                var newName = cm.Request.ToFoodTypeName();
                if (await repo.ExistsByNameAsync(newName))
                {
                    throw RuleFactory.SimpleRuleException
                        (ErrorCategory.Conflict,
                        FoodTypeField.FoodTypeName,
                        ErrorCode.NameAlreadyExists,
                        new Dictionary<string, object>
                        {
                            {ParamField.Value,newName.Value }
                        });
                }

                entity.UpdateName(newName);
                await repo.UpdateAsync(entity);
                await _uow.CommitAsync(token);
                return entity.ToFoodTypeResponse();
            }
            catch
            {
                await _uow.RollBackAsync(token);
                throw;
            }
        }
    }
}