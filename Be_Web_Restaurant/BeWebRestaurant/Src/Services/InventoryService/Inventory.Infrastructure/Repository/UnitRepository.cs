using Inventory.Application.Interfaces;
using Inventory.Domain.Entities;
using Inventory.Domain.ValueObjects.Unit;
using Inventory.Infrastructure.Persitence;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure.Repository
{
    public class UnitRepository : IUnitRepository
    {
        private readonly InventoryDbContext _context;

        public UnitRepository(InventoryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Unit>> GetAllAsync()
        {
            return await _context.Units
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<Unit?> GetByIdAsync(Guid idUnit)
        {
            return await _context.Units
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == idUnit)
                .ConfigureAwait(false);
        }

        public async Task<Unit> CreateAsync(Unit unit)
        {
            await _context.Units.AddAsync(unit).ConfigureAwait(false);
            return unit;
        }

        public Task<Unit> UpdateAsync(Unit unit)
        {
            var entity = _context.Units.Update(unit);
            return Task.FromResult(unit);
        }

        public async Task<bool> DeleteASync(Guid idUnit)
        {
            var entity = await _context.Units.FindAsync(idUnit);
            if (entity is null) return false;
            _context.Units.Remove(entity);
            return true;
        }

        public async Task<bool> ExistsByNameAsync(UnitName unitName)
        {
            return await _context.Units
                .AsNoTracking()
                .AnyAsync(f => f.UnitName == unitName)
                .ConfigureAwait(false);
        }
    }
}