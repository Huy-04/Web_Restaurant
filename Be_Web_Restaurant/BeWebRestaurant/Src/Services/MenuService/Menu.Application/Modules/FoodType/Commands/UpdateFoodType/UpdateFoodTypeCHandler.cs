using Domain.Core.Enums;
using Domain.Core.Rule.RuleFactory;
using MediatR;
using Menu.Application.DTOs.Responses.FoodType;
using Menu.Application.Interfaces;
using Menu.Application.Mapping.FoodTypeMapExtension;
using Menu.Domain.Common.Messages.ErrorMessages;
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
            var repo = _uow.FoodTypeRepo;
            var entity = await repo.GetByIdAsync(cm.IdFoodType);
            if (entity is null)
            {
                throw RuleFactory.SimpleRuleException(ErrorCode.NotFound, FoodTypeField.IdFoodType, new[] { FoodTypeErrors.IdFoodTypeNotFound });
            }
            var newName = cm.Request.ToFoodTypeName();
            if (await repo.ExistsByNameAsync(newName))
            {
                throw RuleFactory.SimpleRuleException(ErrorCode.Conflict, FoodTypeField.FoodTypeName, new[] { FoodTypeErrors.FoodTypeNameexisted });
            }

            entity.UpdateName(newName);
            await repo.UpdateAsync(entity);
            await _uow.SaveChangesAsync(token);
            return entity.ToFoodTypeResponse();
        }
    }
}