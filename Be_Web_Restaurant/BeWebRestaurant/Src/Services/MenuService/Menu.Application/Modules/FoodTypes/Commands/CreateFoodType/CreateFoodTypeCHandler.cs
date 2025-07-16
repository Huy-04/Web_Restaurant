using Domain.Core.Rule;
using Domain.Core.RuleException;
using MediatR;
using Menu.Application.DTOs.Responses.FoodType;
using Menu.Application.Interfaces;
using Menu.Application.Mapping.FoodTypeMapExtension;
using Menu.Domain.Common.Message.FieldNames;
using Menu.Domain.ValueObjects;

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
                throw new BusinessRuleException(new IBusinessRule[]
                { new SimpleBusinessRule(FoodTypeField.NameFoodType,"Food Type Name already exists") });

            var entity = cm.Request.ToFoodType();
            await _uow.FoodTypeRepo.CreateAsync(entity);
            await _uow.SaveChangesAsync(token);

            return entity.ToFoodTypeResponse();
        }
    }
}