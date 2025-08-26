using Domain.Core.Enums;
using Domain.Core.Messages.FieldNames;
using Domain.Core.Rule.RuleFactory;
using MediatR;
using Menu.Application.DTOs.Responses.Food;
using Menu.Application.Interfaces;
using Menu.Application.Mapping.FoodMapExtension;
using Menu.Domain.Common.Messages.FieldNames;

namespace Menu.Application.Modules.Food.Queries.GetFoodById
{
    public sealed class GetFoodByIdQHandler : IRequestHandler<GetFoodByIdQuery, FoodResponse>
    {
        private readonly IUnitOfWork _uow;

        public GetFoodByIdQHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<FoodResponse> Handle(GetFoodByIdQuery query, CancellationToken token)
        {
            var listFoodType = await _uow.FoodTypeRepo.GetAllAsync();
            var entity = await _uow.FoodRepo.GetByIdAsync(query.IdFood);
            if (entity is null)
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

            var type = listFoodType.FirstOrDefault(type => type.Id == entity.FoodTypeId);

            return entity.ToFoodResponse(type!.FoodTypeName);
        }
    }
}