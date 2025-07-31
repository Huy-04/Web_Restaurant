using Menu.Domain.Entities;
using Menu.Domain.ValueObjects.FoodType;

namespace Menu.Application.Interfaces
{
    public interface IFoodTypeRepository
    {
        Task<IEnumerable<FoodType>> GetAllAsync();

        Task<FoodType?> GetByIdAsync(Guid idFoodType);

        Task<FoodType> CreateAsync(FoodType foodType);

        Task<FoodType> UpdateAsync(FoodType foodType);

        Task<bool> DeleteAsync(Guid idFoodType);

        Task<bool> ExistsByNameAsync(FoodTypeName foodTypeName);
    }
}