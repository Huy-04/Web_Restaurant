using Domain.Core.Enums;
using Domain.Core.Messages.FieldNames;
using Domain.Core.Rule.RuleFactory;
using Inventory.Application.DTOs.Responses.StockReceipt;
using Inventory.Application.Interfaces;
using Inventory.Application.Mapping.StockReceiptMapExtension;
using Inventory.Domain.Common.Messages.FieldNames;
using MediatR;

namespace Inventory.Application.Modules.StockReceipt.Commands.UpdateStockReceipt
{
    public sealed class UpdateStockReceiptCHandler : IRequestHandler<UpdateStockReceiptCommand, StockReceiptResponse>
    {
        private readonly IUnitOfWork _uow;

        public UpdateStockReceiptCHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<StockReceiptResponse> Handle(UpdateStockReceiptCommand command, CancellationToken token)
        {
            await _uow.BeginTransactionAsync(token);
            try
            {
                var repo = _uow.StockReceiptRepo;
                var stockReceipt = await repo.GetByIdAsync(command.IdStockReceipt);
                if (stockReceipt is null)
                {
                    throw RuleFactory.SimpleRuleException
                        (ErrorCategory.NotFound,
                        StockReceipField.IdStockReceipt,
                        ErrorCode.IdNotFound,
                        new Dictionary<string, object>
                        {
                            {ParamField.Value,command.IdStockReceipt }
                        });
                }
                var entity = command.Request.ToStockReceipt();
                var unit = await _uow.UnitRepo.GetByIdAsync(entity.UnitId);
                if (unit is null)
                {
                    throw RuleFactory.SimpleRuleException
                        (ErrorCategory.NotFound,
                        UnitField.IdUnit,
                        ErrorCode.IdNotFound,
                        new Dictionary<string, object>
                        {
                            {ParamField.Value,entity.UnitId }
                        });
                }
                var ingredients = await _uow.IngredientsRepo.GetByIdAsync(entity.IngredientsId);
                if (ingredients is null)
                {
                    throw RuleFactory.SimpleRuleException
                        (ErrorCategory.NotFound,
                        IngredientsField.IdIngredients,
                        ErrorCode.IdNotFound,
                        new Dictionary<string, object>
                        {
                            {ParamField.Value,entity.IngredientsId }
                        });
                }

                stockReceipt.Update(entity.IngredientsId, entity.Quantity, entity.UnitId, entity.Prices, entity.Supplier);
                await repo.UpdateAsync(stockReceipt);
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