using Inventory.Application.Interfaces;
using Inventory.Domain.Entities;
using Inventory.Infrastructure.Persitence;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure.Repository
{
    public class FoodRecipesRepository : IFoodRecipesRepository
    {
        private readonly InventoryDbContext _context;

        public FoodRecipesRepository(InventoryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FoodRecipe>> GetAllAsync()
        {
            return await _context.FoodRecipes
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<FoodRecipe?> GetByIdAsync(Guid idFoodRecipe)
        {
            return await _context.FoodRecipes
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == idFoodRecipe)
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<FoodRecipe>> GetByFoodAsync(Guid foodId)
        {
            return await _context.FoodRecipes
                .AsNoTracking()
                .Where(f => f.FoodId == foodId)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<FoodRecipe>> GetByIngredientsAsync(Guid ingredientsId)
        {
            return await _context.FoodRecipes
                .AsNoTracking()
                .Where(f => f.IngredientsId == ingredientsId)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<FoodRecipe> CreateAsync(FoodRecipe foodRecipe)
        {
            await _context.FoodRecipes.AddAsync(foodRecipe).ConfigureAwait(false);
            return foodRecipe;
        }

        public Task<FoodRecipe> UpdateAsync(FoodRecipe foodRecipe)
        {
            var entity = _context.Update(foodRecipe);
            return Task.FromResult(foodRecipe);
        }

        public async Task<bool> DeleteAsync(Guid idFoodRecipe)
        {
            var entity = await _context.FoodRecipes.FindAsync(idFoodRecipe);
            if (entity is null) return false;
            _context.FoodRecipes.Remove(entity);
            return true;
        }
    }
}