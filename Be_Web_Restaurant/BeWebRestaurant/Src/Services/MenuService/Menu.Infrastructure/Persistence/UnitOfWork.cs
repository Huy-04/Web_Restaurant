using Menu.Application.Interfaces;
using System.Threading.Tasks;

namespace Menu.Infrastructure.Persistence
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly MenuDbContext _context;
        public IFoodRepository FoodRepo { get; }
        public IFoodTypeRepository FoodTypeRepo { get; }

        public UnitOfWork(MenuDbContext context, IFoodRepository foodRepo, IFoodTypeRepository foodTypeRepo)
        {
            _context = context;
            FoodRepo = foodRepo;
            FoodTypeRepo = foodTypeRepo;
        }

        public async Task<int> SaveChangesAsync(CancellationToken token = default)
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}