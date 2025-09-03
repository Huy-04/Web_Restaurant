using MediatR;

namespace Inventory.Application.Modules.StockReceipt.Commands.DeleteStockReceipt
{
    public sealed record DeleteStockReceiptCommand(Guid IdStockReceipt) : IRequest<bool>
    {
    }
}