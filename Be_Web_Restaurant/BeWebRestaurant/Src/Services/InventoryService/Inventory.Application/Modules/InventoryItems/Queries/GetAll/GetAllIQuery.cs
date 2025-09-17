using Inventory.Application.DTOs.Responses.StockItems;
using MediatR;

namespace Inventory.Application.Modules.InventoryItems.Queries.GetAll
{
    public sealed record GetAllIQuery() : IRequest<IEnumerable<StockItemsResponse>>
    {
    }
}