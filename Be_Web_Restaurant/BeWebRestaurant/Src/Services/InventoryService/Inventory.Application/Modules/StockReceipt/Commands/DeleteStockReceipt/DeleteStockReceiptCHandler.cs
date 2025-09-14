using Domain.Core.Enums;
using Domain.Core.Messages.FieldNames;
using Domain.Core.Rule.RuleFactory;
using Inventory.Application.Interfaces;
using Inventory.Domain.Common.Messages.FieldNames;
using MediatR;

namespace Inventory.Application.Modules.StockReceipt.Commands.DeleteStockReceipt
{
    public sealed class DeleteStockReceiptCHandler : IRequestHandler<DeleteStockReceiptCommand, bool>
    {
        private readonly IUnitOfWork _uow;

        public DeleteStockReceiptCHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> Handle(DeleteStockReceiptCommand command, CancellationToken token)
        {
            await _uow.BeginTransactionAsync(token);
            try
            {
                var exists = await _uow.StockReceiptRepo.DeleteAsync(command.IdStockReceipt);
                if (!exists)
                {
                    await _uow.RollBackAsync(token);
                    return false;
                }
                await _uow.CommitAsync(token);
                return true;
            }
            catch
            {
                await _uow.RollBackAsync(token);
                throw;
            }
        }
    }
}