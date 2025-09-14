using Domain.Core.Enums;
using Domain.Core.Messages.FieldNames;
using Domain.Core.Rule.RuleFactory;
using MediatR;
using Menu.Application.DTOs.Responses.FoodType;
using Menu.Application.Interfaces;
using Menu.Application.Mapping.FoodTypeMapExtension;
using Menu.Application.Modules.FoodType.Queries.GetById;
using Menu.Domain.Common.Messages.FieldNames;

namespace Menu.Application.Modules.FoodTypes.Queries.GetFoodTypeById
{
    public sealed class GetByIdQHandler : IRequestHandler<GetByIdQuery, FoodTypeResponse>
    {
        private readonly IUnitOfWork _uow;

        public GetByIdQHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<FoodTypeResponse> Handle(GetByIdQuery query, CancellationToken token)
        {
            var foodType = await _uow.FoodTypeRepo.GetByIdAsync(query.IdFoodType);
            if (foodType is null)
            {
                throw RuleFactory.SimpleRuleException
                    (ErrorCategory.NotFound,
                    FoodTypeField.IdFoodType,
                    ErrorCode.IdNotFound,
                    new Dictionary<string, object>
                    {
                        {ParamField.Value,query.IdFoodType }
                    });
            }
            return foodType.ToFoodTypeResponse();
        }
    }
}