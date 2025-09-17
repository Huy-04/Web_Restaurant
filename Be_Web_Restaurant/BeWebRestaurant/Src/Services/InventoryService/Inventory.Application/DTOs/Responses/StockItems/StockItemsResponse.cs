using Common.DTOs.Responses.Measurement;
using Inventory.Domain.ValueObjects.StockItems;

namespace Inventory.Application.DTOs.Responses.StockItems
{
    public sealed record StockItemsResponse(
        Guid IdStockItems,
        Guid StockId,
        Guid IngredientsId,
        string ingredientsName,
        MeasurementResponse Measurement,
        decimal Capacity,
        StockItemsStatus StockItemsStatus,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt
        )
    {
    }
}