using Common.DTOs.Requests;

namespace Inventory.Application.DTOs.Requests.StockReceipt
{
    public sealed record StockReceiptRequest(
        Guid IngredientsId,
        decimal Quantity,
        Guid UnitId,
        IReadOnlyCollection<MoneyRequest> Prices,
        string Supplier)
    {
    }
}