using Inventory.Application.Interfaces;
using Inventory.Infrastructure.Persitence;
using Microsoft.EntityFrameworkCore.Storage;

namespace Inventory.Infrastructure.Persistence
{
    public sealed class UnitOfWork : IUnitOfWork, IDisposable, IAsyncDisposable
    {
        private readonly InventoryDbContext _context;
        private IDbContextTransaction? _transaction;
        public IFoodRecipesRepository FoodRecipesRepo { get; }
        public IIngredientsRepository IngredientsRepo { get; }
        public IInventoryRepository InventoryRepo { get; }
        public IStockReceiptRepository StockReceiptRepo { get; }
        public IUnitRepository UnitRepo { get; }

        public UnitOfWork(InventoryDbContext context, IFoodRecipesRepository foodRecipesRepo,
            IIngredientsRepository ingredientsRepo, IInventoryRepository inventoryRepo,
            IUnitRepository unitRepo, IStockReceiptRepository stockReceiptRepo)
        {
            _context = context;
            FoodRecipesRepo = foodRecipesRepo;
            IngredientsRepo = ingredientsRepo;
            InventoryRepo = inventoryRepo;
            StockReceiptRepo = stockReceiptRepo;
            UnitRepo = unitRepo;
        }

        public async Task BeginTransactionAsync(CancellationToken token)
        {
            if (_transaction is not null) return;
            _transaction = await _context.Database.BeginTransactionAsync(token);
        }

        public async Task CommitAsync(CancellationToken token)
        {
            if (_transaction is null) return;

            try
            {
                await _context.SaveChangesAsync(token);
                await _transaction.CommitAsync(token);
            }
            catch
            {
                await _transaction.RollbackAsync(token);
                throw;
            }
            finally
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task RollBackAsync(CancellationToken token)
        {
            if (_transaction is null) return;

            await _transaction.RollbackAsync(token);
            await _transaction.DisposeAsync();
            _transaction = null;
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}