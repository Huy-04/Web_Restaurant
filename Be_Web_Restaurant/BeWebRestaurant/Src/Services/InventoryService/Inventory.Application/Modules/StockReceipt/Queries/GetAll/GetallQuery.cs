using Inventory.Application.DTOs.Responses.StockReceipt;
using MediatR;

namespace Inventory.Application.Modules.StockReceipt.Queries.GetAll
{
    public sealed record GetallQuery() : IRequest<IEnumerable<StockReceiptResponse>>
    {
    }
}