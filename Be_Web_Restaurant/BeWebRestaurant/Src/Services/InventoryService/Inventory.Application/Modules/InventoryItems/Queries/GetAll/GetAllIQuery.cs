using Inventory.Application.DTOs.Responses.InventoryItems;
using MediatR;

namespace Inventory.Application.Modules.InventoryItems.Queries.GetAll
{
    public sealed record GetAllIQuery() : IRequest<IEnumerable<InventoryItemsResponse>>
    {
    }
}