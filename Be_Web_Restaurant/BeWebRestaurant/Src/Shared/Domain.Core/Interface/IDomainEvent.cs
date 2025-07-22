using MediatR;

namespace Domain.Core.Interface
{
    public interface IDomainEvent : INotification
    {
        DateTimeOffset OccurredOn { get; }
    }
}