using MediatR;
using Menu.Application.Interfaces;

namespace Menu.Application.Modules.Food.Commands.DeleteFood
{
    public sealed class DeleteFoodCHandler : IRequestHandler<DeleteFoodCommand, bool>
    {
        private readonly IUnitOfWork _uow;

        public DeleteFoodCHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> Handle(DeleteFoodCommand command, CancellationToken token)
        {
            await _uow.BeginTransactionAsync(token);
            try
            {
                var exists = await _uow.FoodRepo.DeleteAsync(command.IdFood);
                if (!exists)
                {
                    await _uow.RollBackAsync(token);
                    return false;
                }
                ;
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