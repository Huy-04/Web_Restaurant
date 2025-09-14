using Inventory.Application.DTOs.Responses.InventoryItems;
using MediatR;

namespace Inventory.Application.Modules.InventoryItems.Queries.GetById
{
    public sealed record GetByIdQuery(Guid IdInventory) : IRequest<InventoryItemsResponse>
    {
    }
}