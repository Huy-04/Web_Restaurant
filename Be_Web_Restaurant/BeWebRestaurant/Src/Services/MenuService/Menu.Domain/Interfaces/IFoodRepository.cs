using Menu.Domain.Entities;

namespace Menu.Domain.Interfaces
{
    public interface IFoodRepository
    {
        public Task<IEnumerable<Food>> GetAllAsync();

        public Task<Food> GetByIdÁync(int IdFood);

        public Task<IEnumerable<Food>> GetByFoodTypeAsync(int IdFoodType);

        public Task<Food> CreateAsync(Food food);

        public Task<Food> UpdateAsync(Food food);

        public Task<bool> DeleteAsync(int IdFood);

        public Task<bool> ExistsByNameAsync(string NameFood);
    }

}

