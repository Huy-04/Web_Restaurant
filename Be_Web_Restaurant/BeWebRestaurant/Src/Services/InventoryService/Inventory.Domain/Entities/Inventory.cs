using Domain.Core.Base;
using Domain.Core.ValueObjects;

namespace Inventory.Domain.Entities
{
    public sealed class Inventory : AggregateRoot
    {
        public Guid IdInventory { get; private set; }

        public Description Description { get; private set; }

        public DateTimeOffset CreatedAt { get; private set; }

        public DateTimeOffset UpdatedAt { get; private set; }

        // for orm
        private Inventory()
        {
        }

        private Inventory(Guid id, Description description) : base(id)
        {
            Description = description;
            CreatedAt = UpdatedAt = DateTimeOffset.UtcNow;
        }

        public static Inventory Create(Description description)
        {
            return new Inventory(Guid.NewGuid(), description);
        }

        public void Update(Description description)
        {
            if (Description == description) return;
            Description = description;
            UpdatedAt = DateTimeOffset.UtcNow;
        }
    }
}