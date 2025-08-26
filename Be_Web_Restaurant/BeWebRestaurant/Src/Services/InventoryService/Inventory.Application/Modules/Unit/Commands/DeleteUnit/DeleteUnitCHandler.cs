using Inventory.Application.Interfaces;
using MediatR;

namespace Inventory.Application.Modules.Unit.Commands.DeleteUnit
{
    public sealed class DeleteUnitCHandler : IRequestHandler<DeleteUnitCommand, bool>
    {
        private readonly IUnitOfWork _uow;

        public DeleteUnitCHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> Handle(DeleteUnitCommand cm, CancellationToken token)
        {
            await _uow.BeginTransactionAsync(token);

            try
            {
                var exists = await _uow.UnitRepo.DeleteASync(cm.IdUnit);
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