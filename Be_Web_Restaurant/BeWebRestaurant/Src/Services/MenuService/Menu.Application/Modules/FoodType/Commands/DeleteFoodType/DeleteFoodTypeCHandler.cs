using MediatR;
using Menu.Application.Interfaces;

namespace Menu.Application.Modules.FoodTypes.Commands.DeleteFoodType
{
    public sealed class DeleteFoodTypeCHandler : IRequestHandler<DeleteFoodTypeCommand, bool>
    {
        private readonly IUnitOfWork _uow;

        public DeleteFoodTypeCHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> Handle(DeleteFoodTypeCommand command, CancellationToken token)
        {
            await _uow.BeginTransactionAsync(token);
            try
            {
                var exists = await _uow.FoodTypeRepo.DeleteAsync(command.IdFoodType);
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