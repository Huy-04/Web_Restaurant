using MediatR;
using Menu.Application.DTOs.Responses.FoodType;
using Menu.Application.Interfaces;
using Menu.Application.Mapping.FoodTypeMapExtension;

namespace Menu.Application.Modules.FoodTypes.Queries.GetFoodTypeById
{
    public sealed class GetFoodTypeByIdQHandler : IRequestHandler<GetFoodTypeByIdQuery, FoodTypeResponse?>
    {
        private readonly IUnitOfWork _uow;

        public GetFoodTypeByIdQHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<FoodTypeResponse?> Handle(GetFoodTypeByIdQuery query, CancellationToken token)
        {
            var entity = await _uow.FoodTypeRepo.GetByIdAsync(query.IdFoodType);
            return entity?.ToFoodTypeResponse();
        }
    }
}