using Common.DTOs.Responses;

namespace Inventory.Application.DTOs.Responses.StockReceipt
{
    public sealed record StockReceiptResponse(
        Guid IdStockReceipt,
        Guid IngredientsId,
        decimal Quantity,
        Guid UnitId,
        IReadOnlyCollection<MoneyResponse> Prices,
        string Supplier,
        DateTimeOffset ImportDate)
    {
    }
}