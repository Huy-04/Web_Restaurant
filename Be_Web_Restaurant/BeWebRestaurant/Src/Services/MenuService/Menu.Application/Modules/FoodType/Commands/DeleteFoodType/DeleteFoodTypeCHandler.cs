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

        public async Task<bool> Handle(DeleteFoodTypeCommand cm, CancellationToken token)
        {
            var exists = await _uow.FoodTypeRepo.DeleteAsync(cm.IdFoodType);
            if (!exists) return false;
            await _uow.SaveChangesAsync(token);
            return true;
        }
    }
}