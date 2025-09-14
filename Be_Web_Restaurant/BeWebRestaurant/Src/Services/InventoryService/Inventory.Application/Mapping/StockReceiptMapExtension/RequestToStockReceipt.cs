using Common.DTOs.Requests;
using Common.Mapping.MoneyMapExtension;
using Domain.Core.ValueObjects;
using Inventory.Application.DTOs.Requests.StockReceipt;
using Inventory.Domain.Entities;
using Inventory.Domain.ValueObjects.Common;
using Inventory.Domain.ValueObjects.StockReceipt;

namespace Inventory.Application.Mapping.StockReceiptMapExtension
{
    public static class RequestToStockReceipt
    {
        public static StockReceipt ToStockReceipt(this StockReceiptRequest request)
        {
            return StockReceipt.Create(request.IngredientsId,
                Quantity.Create(request.Quantity),
                request.UnitId,
                request.Prices.ToPrices(),
                Supplier.Create(request.Supplier));
        }
    }
}