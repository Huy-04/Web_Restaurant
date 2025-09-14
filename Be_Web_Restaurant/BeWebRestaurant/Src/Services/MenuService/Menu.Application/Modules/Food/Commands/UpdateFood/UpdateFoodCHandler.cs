using Azure.Core;
using Domain.Core.Enums;
using Domain.Core.Messages.FieldNames;
using Domain.Core.Rule.RuleFactory;
using MediatR;
using Menu.Application.DTOs.Responses.Food;
using Menu.Application.Interfaces;
using Menu.Application.Mapping.FoodMapExtension;
using Menu.Domain.Common.Messages.FieldNames;

namespace Menu.Application.Modules.Food.Commands.UpdateFood
{
    public sealed class UpdateFoodCHandler : IRequestHandler<UpdateFoodCommand, FoodResponse>
    {
        private readonly IUnitOfWork _uow;

        public UpdateFoodCHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<FoodResponse> Handle(UpdateFoodCommand command, CancellationToken token)
        {
            await _uow.BeginTransactionAsync(token);

            try
            {
                var repo = _uow.FoodRepo;
                var food = await repo.GetByIdAsync(command.IdFood);
                if (food is null)
                {
                    throw RuleFactory.SimpleRuleException
                        (ErrorCategory.NotFound,
                        FoodField.IdFood,
                        ErrorCode.IdNotFound,
                        new Dictionary<string, object>
                        {
                            {ParamField.Value,command.IdFood }
                        });
                }
                var foodtype = await _uow.FoodTypeRepo.GetByIdAsync(command.Request.FoodTypeId);
                if (food.FoodTypeId != command.Request.FoodTypeId && foodtype is null)
                {
                    throw RuleFactory.SimpleRuleException
                        (ErrorCategory.NotFound,
                        FoodTypeField.IdFoodType,
                        ErrorCode.IdNotFound,
                        new Dictionary<string, object>
                        {
                            {ParamField.Value,command.Request.FoodTypeId }
                        });
                }
                var newName = command.Request.ToFoodName();
                if (food.FoodName != newName && await _uow.FoodRepo.ExistsByNameAsync(newName))
                {
                    throw RuleFactory.SimpleRuleException
                        (ErrorCategory.Conflict,
                        FoodField.FoodName,
                        ErrorCode.NameAlreadyExists,
                        new Dictionary<string, object>
                        {
                            {ParamField.Value,newName.Value }
                        });
                }

                food.ApplyBasicInfo(command.Request);
                food.ApplyStatus(command.Request);
                food.ApplyMoney(command.Request);
                food.ApplyFoodTypeId(command.Request);

                await _uow.FoodRepo.UpdateAsync(food);
                await _uow.CommitAsync(token);
                return food.ToFoodResponse(foodtype!.FoodTypeName);
            }
            catch
            {
                await _uow.RollBackAsync(token);
                throw;
            }
        }
    }
}