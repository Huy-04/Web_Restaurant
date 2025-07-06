namespace Domain.Core.Rule
{
    public interface IBusinessRule
    {
        string Message { get; }
        string Field { get; }

        bool IsSatisfied();
    }
}