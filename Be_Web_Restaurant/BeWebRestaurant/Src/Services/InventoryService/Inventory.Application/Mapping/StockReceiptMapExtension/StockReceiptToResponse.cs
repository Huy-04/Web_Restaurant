using Common.Mapping.PriceMapExtemsion;
using Inventory.Application.DTOs.Responses.StockReceipt;
using Inventory.Domain.Entities;

namespace Inventory.Application.Mapping.StockReceiptMapExtension
{
    public static class StockReceiptToResponse
    {
        public static StockReceiptResponse ToStockReceiptResponse(this StockReceipt stockReceipt)
        {
            return new(stockReceipt.Id,
                stockReceipt.IngredientsId,
                stockReceipt.Quantity,
                stockReceipt.UnitId,
                stockReceipt.Prices.Items.ToPrices(),
                stockReceipt.Supplier,
                stockReceipt.Importdate);
        }
    }
}