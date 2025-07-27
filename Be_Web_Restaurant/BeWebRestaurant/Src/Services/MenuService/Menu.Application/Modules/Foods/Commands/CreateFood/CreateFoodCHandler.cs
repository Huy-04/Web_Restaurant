using Domain.Core.Rule.RuleFactory;
using Domain.Core.RuleException.Errors;
using MediatR;
using Menu.Application.DTOs.Responses.Food;
using Menu.Application.Interfaces;
using Menu.Application.Mapping.FoodMapExtension;
using Menu.Domain.Common.Message.ErrorMessages;
using Menu.Domain.Common.Message.FieldNames;

namespace Menu.Application.Modules.Foods.Commands.CreateFood
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
            var foodType = await _uow.FoodTypeRepo.GetByIdAsync(cm.Request.FoodTypeId);
            if (foodType is null)
            {
                throw RuleFactory.SimpleRuleException(ErrorCode.NotFound, FoodTypeField.IdFoodType, new[] { FoodTypeMessages.IdFoodTypeNotFound });
            }
            var entity = cm.Request.ToFood();
            if (await _uow.FoodRepo.ExistsByNameAsync(entity.FoodName))
            {
                throw RuleFactory.SimpleRuleException(ErrorCode.Conflict, FoodField.FoodName, new[] { FoodMessages.FoodNameexisted });
            }
            await _uow.FoodRepo.CreateAsync(entity);
            await _uow.SaveChangesAsync(token);

            return entity.ToFoodResponse(foodType.FoodTypeName);
        }
    }
}