using Inventory.Application.DTOs.Responses.InventoryItems;
using Inventory.Application.Interfaces;
using MediatR;

namespace Inventory.Application.Modules.InventoryItems.Queries.GetById
{
    public sealed class GetIByIdQHandler : IRequestHandler<GetByIdQuery, InventoryItemsResponse>
    {
        private readonly IUnitOfWork _uow;

        public GetIByIdQHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<InventoryItemsResponse> Handle(GetByIdQuery query, CancellationToken token)
        {
            var inventory = await _uow.FoodRecipesRepo.GetByIdAsync(query.IdInventory);
            if (inventory is null)
            {
                throw
            }
        }
    }
}