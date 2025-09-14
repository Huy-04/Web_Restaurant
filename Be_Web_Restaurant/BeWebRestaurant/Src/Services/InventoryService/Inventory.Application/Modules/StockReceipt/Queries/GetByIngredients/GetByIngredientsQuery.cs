using Inventory.Application.DTOs.Responses.StockReceipt;
using MediatR;

namespace Inventory.Application.Modules.StockReceipt.Queries.GetByIngredients
{
    public sealed record GetByIngredientsQuery(Guid IngredientsId) : IRequest<IEnumerable<StockReceiptResponse>>
    {
    }
}