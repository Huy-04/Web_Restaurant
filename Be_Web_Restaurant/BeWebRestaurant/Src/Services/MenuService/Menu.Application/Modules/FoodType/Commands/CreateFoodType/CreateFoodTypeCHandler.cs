using Domain.Core.Enums;
using Domain.Core.Messages.FieldNames;
using Domain.Core.Rule.RuleFactory;
using MediatR;
using Menu.Application.DTOs.Responses.FoodType;
using Menu.Application.Interfaces;
using Menu.Application.Mapping.FoodTypeMapExtension;
using Menu.Domain.Common.Messages.FieldNames;
using Menu.Domain.ValueObjects.FoodType;

namespace Menu.Application.Modules.FoodTypes.Commands.CreateFoodType
{
    public sealed class CreateFoodTypeCHandler : IRequestHandler<CreateFoodTypeCommand, FoodTypeResponse>
    {
        private readonly IUnitOfWork _uow;

        public CreateFoodTypeCHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<FoodTypeResponse> Handle(CreateFoodTypeCommand command, CancellationToken token)
        {
            await _uow.BeginTransactionAsync(token);
            try
            {
                var newName = FoodTypeName.Create(command.Request.FoodTypeName);
                if (await _uow.FoodTypeRepo.ExistsByNameAsync(newName))
                {
                    throw RuleFactory.SimpleRuleException
                        (ErrorCategory.Conflict,
                        FoodTypeField.FoodTypeName,
                        ErrorCode.NameAlreadyExists,
                        new Dictionary<string, object>
                        {
                            {ParamField.Value,newName }
                        });
                }

                var foodType = command.Request.ToFoodType();
                await _uow.FoodTypeRepo.CreateAsync(foodType);
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