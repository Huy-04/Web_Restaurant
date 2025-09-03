using Inventory.Application.DTOs.Responses.StockReceipt;
using MediatR;

namespace Inventory.Application.Modules.StockReceipt.Queries.GetStockReceiptByIngredients
{
    public sealed record GetStockReceiptByIngredientsQuery(Guid IngredientsId) : IRequest<IEnumerable<StockReceiptResponse>>
    {
    }
}