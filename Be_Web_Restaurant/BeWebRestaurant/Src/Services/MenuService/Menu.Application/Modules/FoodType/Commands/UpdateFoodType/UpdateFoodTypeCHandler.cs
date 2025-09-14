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

        public async Task<FoodTypeResponse> Handle(UpdateFoodTypeCommand command, CancellationToken token)
        {
            await _uow.BeginTransactionAsync(token);

            try
            {
                var repo = _uow.FoodTypeRepo;
                var foodType = await repo.GetByIdAsync(command.IdFoodType);
                if (foodType is null)
                {
                    throw RuleFactory.SimpleRuleException
                        (ErrorCategory.NotFound,
                        FoodTypeField.IdFoodType,
                        ErrorCode.IdNotFound,
                        new Dictionary<string, object>
                        {
                            {ParamField.Value,command.IdFoodType }
                        });
                }
                var newName = command.Request.ToFoodTypeName();
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

                foodType.UpdateName(newName);
                await repo.UpdateAsync(foodType);
                await _uow.CommitAsync(token);
                return foodType.ToFoodTypeResponse();
            }
            catch
            {
                await _uow.RollBackAsync(token);
                throw;
            }
        }
    }
}