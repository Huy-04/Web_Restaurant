using MediatR;
using Menu.Application.DTOs.Responses.FoodType;
using Menu.Application.Interfaces;
using Menu.Application.Mapping.FoodTypeMapExtension;

namespace Menu.Application.Modules.FoodTypes.Commands.UpdateFoodType
{
    public sealed class UpdateFoodTypeCHandler : IRequestHandler<UpdateFoodTypeCommand, FoodTypeResponse>
    {
        private readonly IUnitOfWork _uow;

        public UpdateFoodTypeCHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<FoodTypeResponse> Handle(UpdateFoodTypeCommand cm, CancellationToken token)
        {
            var repo = _uow.FoodTypeRepo;
            var entity = await repo.GetByIdAsync(cm.Request.IdFoodType);
            var newName = cm.Request.ToFoodTypeName();
            await repo.ExistsByNameAsync(newName);
            await repo.UpdateAsync(entity);
            await _uow.SaveChangesAsync(token);
            return entity.ToFoodTypeResponse();
        }
    }
}