using Domain.Core.Enums;
using Domain.Core.Messages.FieldNames;
using Domain.Core.Rule.RuleFactory;
using MediatR;
using Menu.Application.DTOs.Responses.Food;
using Menu.Application.Interfaces;
using Menu.Application.Mapping.FoodMapExtension;
using Menu.Domain.Common.Messages.FieldNames;

namespace Menu.Application.Modules.Food.Queries.GetByFoodType
{
    public sealed class GetByFoodTypeQHandler : IRequestHandler<GetByFoodTypeQuery, IEnumerable<FoodResponse>>
    {
        private readonly IUnitOfWork _uow;

        public GetByFoodTypeQHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<FoodResponse>> Handle(GetByFoodTypeQuery query, CancellationToken token)
        {
            var listFood = await _uow.FoodRepo.GetByFoodTypeAsync(query.FoodTypeId);
            if (!listFood.Any())
            {
                throw RuleFactory.SimpleRuleException
                    (ErrorCategory.NotFound,
                    FoodTypeField.IdFoodType,
                    ErrorCode.IdNotFound,
                    new Dictionary<string, object>
                    {
                        {ParamField.Value,query.FoodTypeId }
                    });
            }
            var listFoodType = await _uow.FoodTypeRepo.GetAllAsync();
            var list = from f in listFood
                       join ft in listFoodType
                       on f.FoodTypeId equals ft.Id
                       select f.ToFoodResponse(ft.FoodTypeName);
            return list;
        }
    }
}