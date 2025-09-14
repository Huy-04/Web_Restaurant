using Domain.Core.Enums;
using Domain.Core.Messages.FieldNames;
using Domain.Core.Rule.RuleFactory;
using Inventory.Application.DTOs.Responses.StockReceipt;
using Inventory.Application.Interfaces;
using Inventory.Application.Mapping.StockReceiptMapExtension;
using Inventory.Domain.Common.Messages.FieldNames;
using MediatR;

namespace Inventory.Application.Modules.StockReceipt.Queries.GetById
{
    public sealed class GetStockReceiptByIdQHandlercs : IRequestHandler<GetStockReceiptByIdQuery, StockReceiptResponse>
    {
        private readonly IUnitOfWork _uow;

        public GetStockReceiptByIdQHandlercs(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<StockReceiptResponse> Handle(GetStockReceiptByIdQuery query, CancellationToken token)
        {
            var stockReceipt = await _uow.StockReceiptRepo.GetByIdAsync(query.IdStockReceipt);
            if (stockReceipt is null)
            {
                throw RuleFactory.SimpleRuleException
                    (ErrorCategory.NotFound,
                    StockReceipField.IdStockReceipt,
                    ErrorCode.IdNotFound,
                    new Dictionary<string, object>
                    {
                        {ParamField.Value,query.IdStockReceipt }
                    });
            }
            var unit = await _uow.UnitRepo.GetByIdAsync(stockReceipt.UnitId);
            var ingredients = await _uow.IngredientsRepo.GetByIdAsync(stockReceipt.IngredientsId);
            return stockReceipt.ToStockReceiptResponse(ingredients!.IngredientsName, unit!.UnitName);
        }
    }
}