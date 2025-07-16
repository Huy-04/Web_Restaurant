namespace Menu.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IFoodRepository FoodRepo { get; }
        IFoodTypeRepository FoodTypeRepo { get; }

        Task<int> SaveChangesAsync(CancellationToken token);
    }
}