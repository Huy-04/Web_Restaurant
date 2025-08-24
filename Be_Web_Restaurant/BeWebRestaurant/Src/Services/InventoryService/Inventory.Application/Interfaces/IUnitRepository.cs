using Inventory.Domain.Entities;
using Inventory.Domain.ValueObjects.Unit;

namespace Inventory.Application.Interfaces
{
    public interface IUnitRepository
    {
        Task<IEnumerable<Unit>> GetAllAsync();

        Task<Unit?> GetByIdAsync(Guid idUnit);

        Task<Unit> CreateAsync(Unit unit);

        Task<Unit> UpdateAsync(Unit unit);

        Task<bool> DeleteASync(Guid idUnit);

        Task<bool> ExistsByNameAsync(UnitName unitName);
    }
}