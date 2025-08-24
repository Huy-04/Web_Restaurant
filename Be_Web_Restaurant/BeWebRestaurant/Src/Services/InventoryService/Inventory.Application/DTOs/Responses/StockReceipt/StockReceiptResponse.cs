using Common.DTOs.Responses;

namespace Inventory.Application.DTOs.Responses.StockReceipt
{
    public sealed record StockReceiptResponse(
        Guid IdStockReceipt,
        Guid IngredientsId,
        string ingredientsName,
        decimal Quantity,
        Guid UnitId,
        string unitName,
        IReadOnlyCollection<MoneyResponse> Prices,
        string Supplier,
        DateTimeOffset ImportDate)
    {
    }
}