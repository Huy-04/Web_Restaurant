using Inventory.Application.DTOs.Responses.StockItems;
using MediatR;

namespace Inventory.Application.Modules.InventoryItems.Queries.GetById
{
    public sealed record GetByIdQuery(Guid IdInventory) : IRequest<StockItemsResponse>
    {
    }
}