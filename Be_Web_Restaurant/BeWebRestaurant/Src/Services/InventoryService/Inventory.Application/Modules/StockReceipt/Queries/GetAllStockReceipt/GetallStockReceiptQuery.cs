using Inventory.Application.DTOs.Responses.StockReceipt;
using MediatR;

namespace Inventory.Application.Modules.StockReceipt.Queries.GetAllStockReceipt
{
    public sealed record GetallStockReceiptQuery() : IRequest<IEnumerable<StockReceiptResponse>>
    {
    }
}