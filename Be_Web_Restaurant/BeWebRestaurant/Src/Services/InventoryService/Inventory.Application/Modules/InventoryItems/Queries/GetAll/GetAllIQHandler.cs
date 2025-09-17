using Inventory.Application.DTOs.Responses.StockItems;
using Inventory.Application.Interfaces;
using Inventory.Application.Mapping.InventoryItemsMapExtension;
using MediatR;

namespace Inventory.Application.Modules.InventoryItems.Queries.GetAll
{
    public sealed class GetAllIQHandler : IRequestHandler<GetAllIQuery, IEnumerable<StockItemsResponse>>
    {
        private readonly IUnitOfWork _uow;

        public GetAllIQHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<StockItemsResponse>> Handle(GetAllIQuery query, CancellationToken token)
        {
            var inventoryList = await _uow.InventoryRepo.GetAllAsync();
            var ingredientsList = await _uow.IngredientsRepo.GetAllAsync();
            var list = from inventory in inventoryList
                       join i in ingredientsList
                       on inventory.IngredientsId equals i.Id
                       select inventory.ToInventoryItemsResponse(i.IngredientsName);
            return list;
        }
    }
}