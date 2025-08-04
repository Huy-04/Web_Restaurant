using Menu.Domain.Entities;
using Menu.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Menu.Application.Interfaces;
using Menu.Domain.ValueObjects.Food;

namespace Menu.Infrastructure.Repository
{
    public class FoodRepository : IFoodRepository
    {
        private readonly MenuDbContext _context;

        public FoodRepository(MenuDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Food>> GetAllAsync()
        {
            return await _context.Foods
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<Food?> GetByIdAsync(Guid idFood)
        {
            return await _context.Foods
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == idFood)
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<Food>> GetByFoodTypeAsync(Guid idFoodType)
        {
            return await _context.Foods
                .AsNoTracking()
                .Where(f => f.FoodTypeId == idFoodType)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<Food> CreateAsync(Food food)
        {
            await _context.Foods.AddAsync(food).ConfigureAwait(false);
            return food;
        }

        public Task<Food> UpdateAsync(Food food)
        {
            _context.Foods.Update(food);
            return Task.FromResult(food);
        }

        public async Task<bool> DeleteAsync(Guid idFood)
        {
            var food = await _context.Foods.FindAsync(idFood);
            if (food is null)
            {
                return false;
            }
            _context.Foods.Remove(food);
            return true;
        }

        public async Task<bool> ExistsByNameAsync(FoodName foodName)
        {
            return await _context.Foods
                .AsNoTracking()
                .AnyAsync(f => f.FoodName == foodName.Value)
                .ConfigureAwait(false);
        }
    }
}