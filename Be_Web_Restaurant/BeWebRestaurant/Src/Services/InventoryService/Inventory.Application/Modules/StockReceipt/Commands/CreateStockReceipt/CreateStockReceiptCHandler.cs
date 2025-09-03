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

        public async Task<StockReceiptResponse> Handle(CreateStockReceiptCommand cm, CancellationToken token)
        {
            await _uow.BeginTransactionAsync(token);
            try
            {
                var entity = cm.Request.ToStockReceipt();
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
                await _uow.StockReceiptRepo.CreateAsync(entity);
                await _uow.CommitAsync(token);

                return entity.ToStockReceiptResponse(ingredients.IngredientsName, unit.UnitName);
            }
            catch
            {
                await _uow.RollBackAsync(token);
                throw;
            }
        }
    }
}