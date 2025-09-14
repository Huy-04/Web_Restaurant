using Domain.Core.Enums;
using Domain.Core.Messages.FieldNames;
using Domain.Core.Rule.RuleFactory;
using MediatR;
using Menu.Application.DTOs.Responses.Food;
using Menu.Application.Interfaces;
using Menu.Application.Mapping.FoodMapExtension;
using Menu.Domain.Common.Messages.FieldNames;

namespace Menu.Application.Modules.Food.Queries.GetByStatus
{
    public sealed class GetByStatusQHandler : IRequestHandler<GetByStatusQuery, IEnumerable<FoodResponse>>
    {
        private readonly IUnitOfWork _uow;

        public GetByStatusQHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<FoodResponse>> Handle(GetByStatusQuery query, CancellationToken token)
        {
            var lisFood = await _uow.FoodRepo.GetByStatusAsync(query.foodStatus);
            var listFoodType = await _uow.FoodTypeRepo.GetAllAsync();
            var list = from food in lisFood
                       join type in listFoodType on food.FoodTypeId equals type.Id
                       select food.ToFoodResponse(type.FoodTypeName);
            return list;
        }
    }
}