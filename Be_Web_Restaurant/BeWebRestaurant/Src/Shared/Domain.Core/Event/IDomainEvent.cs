namespace Domain.Core.Event
{
    public interface IDomainEvent
    {
        DateTimeOffset OccurredOn { get; }
    }
}