using Domain.Core.Rule.RuleFactory;
using Domain.Core.RuleException.Errors;
using MediatR;
using Menu.Application.DTOs.Responses.FoodType;
using Menu.Application.Interfaces;
using Menu.Application.Mapping.FoodTypeMapExtension;
using Menu.Domain.Common.Message.ErrorMessages;
using Menu.Domain.Common.Message.FieldNames;

namespace Menu.Application.Modules.FoodTypes.Queries.GetFoodTypeById
{
    public sealed class GetFoodTypeByIdQHandler : IRequestHandler<GetFoodTypeByIdQuery, FoodTypeResponse>
    {
        private readonly IUnitOfWork _uow;

        public GetFoodTypeByIdQHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<FoodTypeResponse> Handle(GetFoodTypeByIdQuery query, CancellationToken token)
        {
            var entity = await _uow.FoodTypeRepo.GetByIdAsync(query.IdFoodType);
            if (entity is null)
            {
                throw RuleFactory.SimpleRuleException(ErrorCode.NotFound, FoodTypeField.IdFoodType, new[] { FoodTypeMessages.IdFoodTypeNotFound });
            }
            return entity.ToFoodTypeResponse();
        }
    }
}