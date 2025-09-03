using Domain.Core.Enums;
using Domain.Core.Messages.FieldNames;
using Domain.Core.Rule.RuleFactory;
using MediatR;
using Menu.Application.DTOs.Responses.Food;
using Menu.Application.Interfaces;
using Menu.Application.Mapping.FoodMapExtension;
using Menu.Domain.Common.Messages.FieldNames;

namespace Menu.Application.Modules.Food.Commands.CreateFood
{
    public sealed class CreateFoodCHandler : IRequestHandler<CreateFoodCommand, FoodResponse>
    {
        private readonly IUnitOfWork _uow;

        public CreateFoodCHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<FoodResponse> Handle(CreateFoodCommand cm, CancellationToken token)
        {
            await _uow.BeginTransactionAsync(token);
            try
            {
                var foodType = await _uow.FoodTypeRepo.GetByIdAsync(cm.Request.FoodTypeId);
                if (foodType is null)
                {
                    throw RuleFactory.SimpleRuleException
                        (ErrorCategory.NotFound,
                        FoodTypeField.IdFoodType,
                        ErrorCode.IdNotFound,
                        new Dictionary<string, object>
                        {
                            {ParamField.Value,cm.Request.FoodTypeId }
                        });
                }
                var entity = cm.Request.ToFood();
                if (await _uow.FoodRepo.ExistsByNameAsync(entity.FoodName))
                {
                    throw RuleFactory.SimpleRuleException
                        (ErrorCategory.Conflict,
                        FoodField.FoodName,
                        ErrorCode.NameAlreadyExists,
                        new Dictionary<string, object>
                        {
                            {ParamField.Value,entity.FoodName.Value }
                        });
                }
                await _uow.FoodRepo.CreateAsync(entity);
                await _uow.CommitAsync(token);

                return entity.ToFoodResponse(foodType.FoodTypeName);
            }
            catch
            {
                await _uow.RollBackAsync(token);
                throw;
            }
        }
    }
}