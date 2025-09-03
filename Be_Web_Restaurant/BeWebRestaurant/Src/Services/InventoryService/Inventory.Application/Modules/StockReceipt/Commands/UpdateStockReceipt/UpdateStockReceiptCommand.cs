using Domain.Core.Rule;
using Domain.Core.Rule.RuleFactory;
using Inventory.Application.DTOs.Requests.StockReceipt;
using Inventory.Application.DTOs.Responses.StockReceipt;
using Inventory.Domain.Common.Factories.Rule;
using MediatR;

namespace Inventory.Application.Modules.StockReceipt.Commands.UpdateStockReceipt
{
    public sealed record UpdateStockReceiptCommand(Guid IdStockReceipt, StockReceiptRequest Request)
        : IRequest<StockReceiptResponse>, IValidateRequest
    {
        public IEnumerable<IBusinessRule> GetRule()
        {
            yield return QuantityRuleFactory.QuantityNotNegative(Request.Quantity);
            yield return StockReceiptRuleFactory.NameNotEmpty(Request.Supplier);
            yield return StockReceiptRuleFactory.NameMaxLength(Request.Supplier);
            foreach (var price in Request.Prices)
            {
                yield return MoneyRuleFactory.CurrencyValidate(price.CurrencyEnum);
                yield return MoneyRuleFactory.AmountNotNegative(price.Amount);
            }
        }
    }
}