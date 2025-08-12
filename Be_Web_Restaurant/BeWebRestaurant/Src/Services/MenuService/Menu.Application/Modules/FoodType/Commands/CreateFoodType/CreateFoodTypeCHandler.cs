using Domain.Core.Enums;
using Domain.Core.Rule.RuleFactory;
using MediatR;
using Menu.Application.DTOs.Responses.FoodType;
using Menu.Application.Interfaces;
using Menu.Application.Mapping.FoodTypeMapExtension;
using Menu.Domain.Common.Messages.ErrorMessages;
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

        public async Task<FoodTypeResponse> Handle(CreateFoodTypeCommand cm, CancellationToken token)
        {
            var newName = FoodTypeName.Create(cm.Request.FoodTypeName);
            if (await _uow.FoodTypeRepo.ExistsByNameAsync(newName))
            {
                throw RuleFactory.SimpleRuleException(ErrorCode.Conflict, FoodTypeField.FoodTypeName, new[] { FoodTypeErrors.FoodTypeNameexisted });
            }

            var entity = cm.Request.ToFoodType();
            await _uow.FoodTypeRepo.CreateAsync(entity);
            await _uow.SaveChangesAsync(token);

            return entity.ToFoodTypeResponse();
        }
    }
}