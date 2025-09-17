using Domain.Core.ValueObjects;
using Inventory.Application.DTOs.Requests.Stock;
using Inventory.Domain.Entities;

namespace Inventory.Application.Mapping.StockMapExtension
{
    public static class RequestToStock
    {
        public static Stock ToStock(this StockRequest request)
        {
            return Stock.Create(Description.Create(request.Description));
        }
    }
}