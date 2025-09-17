using Inventory.Application.DTOs.Responses.StockItems;
using Inventory.Application.Interfaces;
using MediatR;

namespace Inventory.Application.Modules.InventoryItems.Queries.GetById
{
    public sealed class GetIByIdQHandler : IRequestHandler<GetByIdQuery, StockItemsResponse>
    {
        private readonly IUnitOfWork _uow;

        public GetIByIdQHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<StockItemsResponse> Handle(GetByIdQuery query, CancellationToken token)
        {
            var inventory = await _uow.FoodRecipesRepo.GetByIdAsync(query.IdInventory);
            if (inventory is null)
            {
                throw
            }
        }
    }
}