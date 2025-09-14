using Domain.Core.Enums;
using Domain.Core.Messages.FieldNames;
using Domain.Core.Rule.RuleFactory;
using Inventory.Application.DTOs.Responses.StockReceipt;
using Inventory.Application.Interfaces;
using Inventory.Application.Mapping.StockReceiptMapExtension;
using Inventory.Domain.Common.Messages.FieldNames;
using MediatR;

namespace Inventory.Application.Modules.StockReceipt.Commands.CreateStockReceipt
{
    public sealed class CreateStockReceiptCHandler : IRequestHandler<CreateStockReceiptCommand, StockReceiptResponse>
    {
        private readonly IUnitOfWork _uow;

        public CreateStockReceiptCHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<StockReceiptResponse> Handle(CreateStockReceiptCommand command, CancellationToken token)
        {
            await _uow.BeginTransactionAsync(token);
            try
            {
                var stockReceipt = command.Request.ToStockReceipt();
                var unit = await _uow.UnitRepo.GetByIdAsync(stockReceipt.UnitId);
                if (unit is null)
                {
                    throw RuleFactory.SimpleRuleException
                         (ErrorCategory.NotFound,
                         UnitField.IdUnit,
                         ErrorCode.IdNotFound,
                         new Dictionary<string, object>
                         {
                            {ParamField.Value,stockReceipt.UnitId }
                         });
                }
                var ingredients = await _uow.IngredientsRepo.GetByIdAsync(stockReceipt.IngredientsId);
                if (ingredients is null)
                {
                    throw RuleFactory.SimpleRuleException
                         (ErrorCategory.NotFound,
                         IngredientsField.IdIngredients,
                         ErrorCode.IdNotFound,
                         new Dictionary<string, object>
                         {
                            {ParamField.Value,stockReceipt.IngredientsId }
                         });
                }
                await _uow.StockReceiptRepo.CreateAsync(stockReceipt);
                await _uow.CommitAsync(token);

                return stockReceipt.ToStockReceiptResponse(ingredients.IngredientsName, unit.UnitName);
            }
            catch
            {
                await _uow.RollBackAsync(token);
                throw;
            }
        }
    }
}