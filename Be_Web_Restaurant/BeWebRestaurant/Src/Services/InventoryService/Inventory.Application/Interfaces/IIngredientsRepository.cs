using Inventory.Domain.Entities;
using Inventory.Domain.ValueObjects.Ingredients;

namespace Inventory.Application.Interfaces
{
    public interface IIngredientsRepository
    {
        Task<IEnumerable<Ingredients>> GetAllAsync();

        Task<Ingredients?> GetByIdAsync(Guid idIngredients);

        Task<Ingredients> CreateAsync(Ingredients ingredients);

        Task<Ingredients> UpdateAsync(Ingredients ingredients);

        Task<bool> DeleteAsync(Guid idIngredients);

        Task<bool> ExistsByNameAsync(IngredientsName ingredientsName);
    }
}