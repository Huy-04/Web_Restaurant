using Inventory.Application.DTOs.Responses.StockReceipt;
using MediatR;

namespace Inventory.Application.Modules.StockReceipt.Queries.GetStockReceiptById
{
    public sealed record GetStockReceiptByIdQuery(Guid IdStockReceipt) : IRequest<StockReceiptResponse>
    {
    }
}