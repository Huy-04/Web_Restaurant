using Inventory.Application.Interfaces;
using MediatR;

namespace Inventory.Application.Modules.FoodRecipe.Commands.DeleteFoodRecipe
{
    public sealed class DeleteFoodRecipeCHandler : IRequestHandler<DeleteFoodRecipeCommand, bool>
    {
        private readonly IUnitOfWork _uow;

        public DeleteFoodRecipeCHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> Handle(DeleteFoodRecipeCommand command, CancellationToken token)
        {
            await _uow.BeginTransactionAsync(token);
            try
            {
                var exists = await _uow.FoodRecipesRepo.DeleteAsync(command.IdFoodRecipe);
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