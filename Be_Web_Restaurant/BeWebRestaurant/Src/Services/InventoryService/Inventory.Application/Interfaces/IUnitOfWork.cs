namespace Inventory.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IFoodRecipesRepository FoodRecipesRepo { get; }

        IInventoryItemsRepository InventoryItemsRepo { get; }

        IIngredientsRepository IngredientsRepo { get; }

        IStockReceiptRepository StockReceiptRepo { get; }

        IUnitRepository UnitRepo { get; }

        public Task BeginTransactionAsync(CancellationToken token = default);

        public Task CommitAsync(CancellationToken token = default);

        public Task RollBackAsync(CancellationToken token = default);
    }
}