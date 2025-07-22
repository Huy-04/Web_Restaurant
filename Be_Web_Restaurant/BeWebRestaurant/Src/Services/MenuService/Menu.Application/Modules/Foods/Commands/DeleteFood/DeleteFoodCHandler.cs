using MediatR;
using Menu.Application.Interfaces;

namespace Menu.Application.Modules.Foods.Commands.DeleteFood
{
    public sealed class DeleteFoodCHandler : IRequestHandler<DeleteFoodCommand, bool>
    {
        private readonly IUnitOfWork _uow;

        public DeleteFoodCHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> Handle(DeleteFoodCommand cm, CancellationToken token)
        {
            var exists = await _uow.FoodRepo.DeleteAsync(cm.IdFood);
            if (!exists) return false;
            await _uow.SaveChangesAsync(token);
            return true;
        }
    }
}