using Common.Mapping.MeasurementMapExtension;
using Inventory.Application.DTOs.Responses.StockItems;
using Inventory.Domain.Entities;

namespace Inventory.Application.Mapping.StockItemsMapExtension
{
    public static class StockItemsToResponse
    {
        public static StockItemsResponse ToInventoryItemsResponse
            (this StockItems stockItems, string ingredientsName)
        {
            return new(
                stockItems.Id,
                stockItems.StockId,
                stockItems.IngredientsId,
                ingredientsName,
                stockItems.Measurement.ToMeasurementResponse(),
                stockItems.Capacity,
                stockItems.StockItemsStatus,
                stockItems.CreatedAt,
                stockItems.UpdatedAt);
        }
    }
}