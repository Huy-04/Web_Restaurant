using Domain.Core.Base;
using Inventory.Domain.ValueObjects.Unit;

namespace Inventory.Domain.Entities
{
    public sealed class Unit : AggregateRoot
    {
        public UnitName UnitName { get; private set; }

        public DateTimeOffset CreatedAt { get; private set; }

        public DateTimeOffset UpdatedAt { get; private set; }

        private Unit()
        { }

        private Unit(Guid id, UnitName unitName)
            : base(id)
        {
            UnitName = unitName;
            CreatedAt = UpdatedAt = DateTimeOffset.UtcNow;
        }

        public static Unit Create(UnitName unitName)
        {
            var entity = new Unit(Guid.NewGuid(), unitName);

            return entity;
        }

        public void Update(UnitName unitName)
        {
            UnitName = unitName;
            UpdatedAt = DateTimeOffset.UtcNow;
        }
    }
}