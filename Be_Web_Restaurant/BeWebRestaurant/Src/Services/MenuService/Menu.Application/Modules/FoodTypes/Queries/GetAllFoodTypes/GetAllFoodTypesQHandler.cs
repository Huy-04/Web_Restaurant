using MediatR;
using Menu.Application.DTOs.Responses.FoodType;
using Menu.Application.Interfaces;
using Menu.Application.Mapping.FoodTypeMapExtension;
using Menu.Application.Modules.FoodTypes.Queries.GetAllFoodType;

namespace Menu.Application.Modules.FoodTypes.Queries.GetAllFoodTypes
{
    public sealed class GetAllFoodTypesQHandler : IRequestHandler<GetAllFoodTypesQuery, IEnumerable<FoodTypeResponse>>
    {
        private readonly IUnitOfWork _uow;

        public GetAllFoodTypesQHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<FoodTypeResponse>> Handle(GetAllFoodTypesQuery query, CancellationToken token)
        {
            var list = await _uow.FoodTypeRepo.GetAllAsync();
            return list.Select(ft => ft.ToFoodTypeResponse());
        }
    }
}