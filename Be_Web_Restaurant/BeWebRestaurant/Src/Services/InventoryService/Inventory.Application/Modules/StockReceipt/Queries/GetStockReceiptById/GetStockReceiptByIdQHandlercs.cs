using Domain.Core.Enums;
using Domain.Core.Messages.FieldNames;
using Domain.Core.Rule.RuleFactory;
using Inventory.Application.DTOs.Responses.StockReceipt;
using Inventory.Application.Interfaces;
using Inventory.Application.Mapping.StockReceiptMapExtension;
using Inventory.Domain.Common.Messages.FieldNames;
using MediatR;

namespace Inventory.Application.Modules.StockReceipt.Queries.GetStockReceiptById
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
            var entity = await _uow.StockReceiptRepo.GetByIdAsync(query.IdStockReceipt);
            if (entity is null)
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
            var unit = await _uow.UnitRepo.GetByIdAsync(entity.UnitId);
            var ingredients = await _uow.IngredientsRepo.GetByIdAsync(entity.IngredientsId);
            return entity.ToStockReceiptResponse(ingredients!.IngredientsName, unit!.UnitName);
        }
    }
}