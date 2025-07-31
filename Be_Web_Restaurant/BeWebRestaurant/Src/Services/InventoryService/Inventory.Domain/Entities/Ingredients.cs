using Domain.Core.Base;
using Inventory.Domain.ValueObjects.Ingredients;

namespace Inventory.Domain.Entities
{
    public sealed class Ingredients : AggregateRoot
    {
        public IngredientsName IngredientsName { get; private set; }

        public Guid UnitId { get; private set; }

        public DateTimeOffset CreatedAt { get; private set; }

        public DateTimeOffset UpdatedAt { get; private set; }

        // for orm
        private Ingredients()
        {
        }

        private Ingredients(Guid id, IngredientsName ingredientsName, Guid unitId) : base(id)
        {
            IngredientsName = ingredientsName;
            UnitId = unitId;
            CreatedAt = UpdatedAt = DateTimeOffset.UtcNow;
        }

        public Ingredients Create(IngredientsName ingredientsName, Guid unitId)
        {
            var entity = new Ingredients(Guid.NewGuid(), ingredientsName, unitId);

            return entity;
        }

        public void Update(IngredientsName ingredientsName, Guid unitId)
        {
            IngredientsName = ingredientsName;
            UnitId = unitId;
            UpdatedAt = DateTimeOffset.UtcNow;
        }
    }
}