using Inventory.Application.DTOs.Responses.Ingredients;
using Inventory.Application.Interfaces;
using Inventory.Application.Mapping.IngredientsMapExtension;
using MediatR;

namespace Inventory.Application.Modules.Ingredients.Queries.GetAllIngdients
{
    public sealed class GetAllIngdientsQHandler : IRequestHandler<GetAllIngredientsQuery, IEnumerable<IngredientsResponse>>
    {
        private readonly IUnitOfWork _uow;

        public GetAllIngdientsQHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<IngredientsResponse>> Handle(GetAllIngredientsQuery query, CancellationToken token)
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