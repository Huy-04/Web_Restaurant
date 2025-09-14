using Common.Mapping.MoneyMapExtension;
using Common.Mapping.PriceMapExtemsion;
using Inventory.Application.DTOs.Responses.StockReceipt;
using Inventory.Domain.Entities;

namespace Inventory.Application.Mapping.StockReceiptMapExtension
{
    public static class StockReceiptToResponse
    {
        public static StockReceiptResponse ToStockReceiptResponse
            (this StockReceipt stockReceipt, string ingredientsName, string unitName)
        {
            return new(stockReceipt.Id,
                stockReceipt.IngredientsId,
                ingredientsName,
                stockReceipt.Quantity,
                stockReceipt.UnitId,
                unitName,
                stockReceipt.Prices.Items.ToPrices(),
                stockReceipt.Supplier,
                stockReceipt.Importdate);
        }
    }
}