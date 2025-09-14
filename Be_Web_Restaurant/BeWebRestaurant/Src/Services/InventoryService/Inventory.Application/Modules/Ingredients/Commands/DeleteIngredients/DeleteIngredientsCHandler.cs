using Inventory.Application.Interfaces;
using MediatR;

namespace Inventory.Application.Modules.Ingredients.Commands.DeleteIngredients
{
    public sealed class DeleteIngredientsCHandler : IRequestHandler<DeleteIngredientsCommand, bool>
    {
        private readonly IUnitOfWork _uow;

        public DeleteIngredientsCHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> Handle(DeleteIngredientsCommand command, CancellationToken token)
        {
            await _uow.BeginTransactionAsync(token);

            try
            {
                var exists = await _uow.IngredientsRepo.DeleteAsync(command.IdIngredients);
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