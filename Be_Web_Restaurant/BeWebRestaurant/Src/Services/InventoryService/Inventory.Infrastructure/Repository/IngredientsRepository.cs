using Inventory.Application.Interfaces;
using Inventory.Domain.Entities;
using Inventory.Domain.ValueObjects.Ingredients;
using Inventory.Infrastructure.Persitence;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure.Repository
{
    public class IngredientsRepository : IIngredientsRepository
    {
        private readonly InventoryDbContext _context;

        public IngredientsRepository(InventoryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ingredients>> GetAllAsync()
        {
            return await _context.Ingredients
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<Ingredients?> GetByIdAsync(Guid idIngredients)
        {
            return await _context.Ingredients
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.Id == idIngredients)
                .ConfigureAwait(false);
        }

        public async Task<Ingredients> CreateAsync(Ingredients ingredients)
        {
            await _context.Ingredients.AddAsync(ingredients).ConfigureAwait(false);
            return ingredients;
        }

        public Task<Ingredients> UpdateAsync(Ingredients ingredients)
        {
            var entity = _context.Update(ingredients);
            return Task.FromResult(ingredients);
        }

        public async Task<bool> DeleteAsync(Guid idIngredients)
        {
            var entity = await _context.Ingredients.FindAsync(idIngredients);
            if (entity is null) return false;
            _context.Ingredients.Remove(entity);
            return true;
        }

        public async Task<bool> ExistsByNameAsync(IngredientsName ingredientsName)
        {
            return await _context.Ingredients
                .AsNoTracking()
                .AnyAsync(i => i.IngredientsName == ingredientsName)
                .ConfigureAwait(false);
        }
    }
}