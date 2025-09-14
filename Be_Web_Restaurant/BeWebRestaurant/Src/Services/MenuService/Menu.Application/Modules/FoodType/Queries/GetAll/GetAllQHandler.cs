using MediatR;
using Menu.Application.DTOs.Responses.FoodType;
using Menu.Application.Interfaces;
using Menu.Application.Mapping.FoodTypeMapExtension;

namespace Menu.Application.Modules.FoodType.Queries.GetAll
{
    public sealed class GetAllQHandler : IRequestHandler<GetAllQuery, IEnumerable<FoodTypeResponse>>
    {
        private readonly IUnitOfWork _uow;

        public GetAllQHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<FoodTypeResponse>> Handle(GetAllQuery query, CancellationToken token)
        {
            var list = await _uow.FoodTypeRepo.GetAllAsync();
            return list.Select(ft => ft.ToFoodTypeResponse());
        }
    }
}