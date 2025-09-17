using Common.DTOs.Requests.Measurement;
using Inventory.Domain.ValueObjects.StockItems;

namespace Inventory.Application.DTOs.Requests.StockItems
{
    public sealed record UpdateStockItemsRequest(
        Guid StockId,
        Guid IngredientsId,
        MeasurementRequest Measurement,
        Capacity Capacity,
        StockItemsStatus StockItemsStatus)
    {
    }
}