using Domain.Core.Base;
using Domain.Core.ValueObjects;

namespace Inventory.Domain.Entities
{
    public sealed class Stock : AggregateRoot
    {
        public Description Description { get; private set; }

        public DateTimeOffset CreatedAt { get; private set; }

        public DateTimeOffset UpdatedAt { get; private set; }

        // for orm
        private Stock()
        {
        }

        private Stock(Guid id, Description description) : base(id)
        {
            Description = description;
            CreatedAt = UpdatedAt = DateTimeOffset.UtcNow;
        }

        public static Stock Create(Description description)
        {
            return new Stock(Guid.NewGuid(), description);
        }

        public void Update(Description description)
        {
            if (Description == description) return;
            Description = description;
            UpdatedAt = DateTimeOffset.UtcNow;
        }
    }
}