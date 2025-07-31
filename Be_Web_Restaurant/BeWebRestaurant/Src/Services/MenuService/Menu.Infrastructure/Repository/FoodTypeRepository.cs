using Menu.Application.Interfaces;
using Menu.Domain.Entities;
using Menu.Domain.ValueObjects.FoodType;
using Menu.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Menu.Infrastructure.Repository
{
    public class FoodTypeRepository : IFoodTypeRepository
    {
        private readonly MenuDbContext _context;

        public FoodTypeRepository(MenuDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FoodType>> GetAllAsync()
        {
            return await _context.FoodTypes
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<FoodType?> GetByIdAsync(Guid idFoodType)
        {
            return await _context.FoodTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(ft => ft.Id == idFoodType)
                .ConfigureAwait(false);
        }

        public async Task<FoodType> CreateAsync(FoodType foodType)
        {
            await _context.FoodTypes
                .AddAsync(foodType)
                .ConfigureAwait(false);
            return foodType;
        }

        public Task<FoodType> UpdateAsync(FoodType foodType)
        {
            _context.FoodTypes
                .Update(foodType);
            return Task.FromResult(foodType);
        }

        public async Task<bool> DeleteAsync(Guid idFoodType)
        {
            var foodtype = await _context.FoodTypes.FindAsync(idFoodType);
            if (foodtype is null)
            {
                return false;
            }
            _context.FoodTypes.Remove(foodtype);
            return true;
        }

        public async Task<bool> ExistsByNameAsync(FoodTypeName foodTypeName)
        {
            return await _context.FoodTypes
                .AsNoTracking()
                .AnyAsync(ft => ft.FoodTypeName == foodTypeName)
                .ConfigureAwait(false);
        }
    }
}