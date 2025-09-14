using Domain.Core.Enums;
using Domain.Core.Messages.FieldNames;
using Domain.Core.Rule.RuleFactory;
using MediatR;
using Menu.Application.DTOs.Responses.Food;
using Menu.Application.Interfaces;
using Menu.Application.Mapping.FoodMapExtension;
using Menu.Domain.Common.Messages.FieldNames;

namespace Menu.Application.Modules.Food.Queries.GetById
{
    public sealed class GetByIdQHandler : IRequestHandler<GetByIdQuery, FoodResponse>
    {
        private readonly IUnitOfWork _uow;

        public GetByIdQHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<FoodResponse> Handle(GetByIdQuery query, CancellationToken token)
        {
            var food = await _uow.FoodRepo.GetByIdAsync(query.IdFood);
            if (food is null)
            {
                throw RuleFactory.SimpleRuleException
                    (ErrorCategory.NotFound,
                    FoodField.IdFood,
                    ErrorCode.IdNotFound,
                    new Dictionary<string, object>
                    {
                        {ParamField.Value,query.IdFood }
                    });
            }
            var foodType = await _uow.FoodTypeRepo.GetByIdAsync(food.FoodTypeId);
            if (foodType is null)
            {
                throw RuleFactory.SimpleRuleException
                    (ErrorCategory.NotFound,
                    FoodTypeField.IdFoodType,
                    ErrorCode.IdNotFound,
                    new Dictionary<string, object>
                    {
                        {ParamField.Value, food.FoodTypeId }
                    });
            }
            return food.ToFoodResponse(foodType.FoodTypeName);
        }
    }
}