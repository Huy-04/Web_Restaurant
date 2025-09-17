using Common.Mapping.MeasurementMapExtension;
using Domain.Core.ValueObjects;
using Inventory.Application.DTOs.Requests.StockItems;
using Inventory.Domain.Entities;
using Inventory.Domain.ValueObjects.StockItems;

namespace Inventory.Application.Mapping.StockItemsMapExtension
{
    public static class RequestToStockItems
    {
        public static StockItems ToStockItems(this CreateStockItemsRequest request)
        {
            return StockItems.Create(
                request.IngredientsId,
                request.StockId,
                Capacity.Create(request.Capacity),
                request.UnitEnum
                );
        }

        public static Measurement ToMeasurement(this UpdateStockItemsRequest request)
        {
            return Measurement.Create(request.Measurement.Quantity, request.Measurement.UnitEnum);
        }

        public static Capacity ToCapacity(this UpdateStockItemsRequest request)
        {
            return Capacity.Create(request.Capacity);
        }

        public static StockItemsStatus ToStockItemsStatus(this UpdateStockItemsRequest request)
        {
            return StockItemsStatus.Create(request.StockItemsStatus);
        }

        public static void ApplyCapacity(this StockItems stockItems, UpdateStockItemsRequest request)
        {
            stockItems.UpdateCapacity(request.ToCapacity());
        }

        public static void ApplyStatus(this StockItems stockItems, UpdateStockItemsRequest request)
        {
            stockItems.UpdateStatus(request.ToStockItemsStatus());
        }

        public static void ApplyMeasurement(this StockItems stockItems, UpdateStockItemsRequest request)
        {
            stockItems.UpdateMeasurement(request.ToMeasurement());
        }
    }
}