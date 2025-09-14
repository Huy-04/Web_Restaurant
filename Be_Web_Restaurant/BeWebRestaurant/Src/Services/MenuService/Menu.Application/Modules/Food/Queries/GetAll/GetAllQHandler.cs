using MediatR;
using Menu.Application.DTOs.Responses.Food;
using Menu.Application.Interfaces;
using Menu.Application.Mapping.FoodMapExtension;

namespace Menu.Application.Modules.Food.Queries.GetAll
{
    public sealed class GetAllQHandler : IRequestHandler<GetAllQuery, IEnumerable<FoodResponse>>
    {
        private readonly IUnitOfWork _uow;

        public GetAllQHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<FoodResponse>> Handle(GetAllQuery query, CancellationToken token)
        {
            var listFood = await _uow.FoodRepo.GetAllAsync();
            var listFoodType = await _uow.FoodTypeRepo.GetAllAsync();

            var list = from food in listFood
                       join type in listFoodType on food.FoodTypeId equals type.Id
                       select food.ToFoodResponse(type.FoodTypeName);

            return list;
        }
    }
}