namespace Domain.Core.Interface
{
    public interface IDomainEvent
    {
        DateTimeOffset OccurredOn { get; }
    }
}