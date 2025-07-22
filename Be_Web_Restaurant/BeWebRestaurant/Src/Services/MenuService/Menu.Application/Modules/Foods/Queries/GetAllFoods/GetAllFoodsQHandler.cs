using MediatR;
using Menu.Application.DTOs.Responses.Food;
using Menu.Application.Interfaces;
using Menu.Application.Mapping.FoodMapExtension;

namespace Menu.Application.Modules.Foods.Queries.GetAllFoods
{
    public sealed class GetAllFoodsQHandler : IRequestHandler<GetAllFoodsQuery, IEnumerable<FoodResponse>>
    {
        private readonly IUnitOfWork _uow;

        public GetAllFoodsQHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<FoodResponse>> Handle(GetAllFoodsQuery query, CancellationToken token)
        {
            var list = await _uow.FoodRepo.GetAllAsync();
            return list.Select(f => f.ToFoodResponse());
        }
    }
}