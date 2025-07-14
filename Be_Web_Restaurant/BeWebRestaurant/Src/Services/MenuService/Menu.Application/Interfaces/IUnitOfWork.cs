using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IFoodRepository FoodRepo { get; }
        IFoodTypeRepository FoodTypeRepo { get; }

        Task<int> SaveChangesAsync(CancellationToken token);
    }
}