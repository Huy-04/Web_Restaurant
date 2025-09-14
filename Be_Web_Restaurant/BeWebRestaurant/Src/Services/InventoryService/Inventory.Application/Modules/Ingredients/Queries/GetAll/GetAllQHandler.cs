using Inventory.Application.DTOs.Responses.Ingredients;
using Inventory.Application.Interfaces;
using Inventory.Application.Mapping.IngredientsMapExtension;
using MediatR;

namespace Inventory.Application.Modules.Ingredients.Queries.GetAll
{
    public sealed class GetAllQHandler : IRequestHandler<GetAllQuery, IEnumerable<IngredientsResponse>>
    {
        private readonly IUnitOfWork _uow;

        public GetAllQHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<IngredientsResponse>> Handle(GetAllQuery query, CancellationToken token)
        {
            var ingredientsList = await _uow.IngredientsRepo.GetAllAsync();
            var unitList = await _uow.UnitRepo.GetAllAsync();

            var list = from i in ingredientsList
                       join u in unitList
                       on i.UnitId equals u.Id
                       select i.ToIngredientsResponse(u.UnitName);
            return list;
        }
    }
}