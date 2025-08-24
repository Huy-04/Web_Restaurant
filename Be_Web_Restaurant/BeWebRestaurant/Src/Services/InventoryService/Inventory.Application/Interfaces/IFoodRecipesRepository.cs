using Inventory.Domain.Entities;

namespace Inventory.Application.Interfaces
{
    public interface IFoodRecipesRepository
    {
        Task<IEnumerable<FoodRecipe>> GetAllAsync();

        Task<FoodRecipe?> GetByIdAsync(Guid idFoodRecipe);

        Task<IEnumerable<FoodRecipe>> GetByFoodAsync(Guid foodId);

        Task<IEnumerable<FoodRecipe>> GetByIngredientsAsync(Guid ingredientsId);

        Task<FoodRecipe> CreateAsync(FoodRecipe foodRecipe);

        Task<FoodRecipe> UpdateAsync(FoodRecipe foodRecipe);

        Task<bool> DeleteAsync(Guid idFoodRecipe);
    }
}