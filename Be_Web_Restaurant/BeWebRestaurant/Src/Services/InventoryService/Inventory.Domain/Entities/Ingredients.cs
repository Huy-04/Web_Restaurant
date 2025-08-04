using Domain.Core.Base;
using Domain.Core.ValueObjects;
using Inventory.Domain.ValueObjects.Ingredients;

namespace Inventory.Domain.Entities
{
    public sealed class Ingredients : AggregateRoot
    {
        public IngredientsName IngredientsName { get; private set; }

        public Guid UnitId { get; private set; }

        public Description Description { get; private set; }

        public DateTimeOffset CreatedAt { get; private set; }

        public DateTimeOffset UpdatedAt { get; private set; }

        // for orm
        private Ingredients()
        {
        }

        private Ingredients(Guid id, IngredientsName ingredientsName, Description description, Guid unitId) : base(id)
        {
            IngredientsName = ingredientsName;
            Description = description;
            UnitId = unitId;
            CreatedAt = UpdatedAt = DateTimeOffset.UtcNow;
        }

        public static Ingredients Create(IngredientsName ingredientsName, Description description, Guid unitId)
        {
            var entity = new Ingredients(Guid.NewGuid(), ingredientsName, description, unitId);

            return entity;
        }

        public void Update(IngredientsName ingredientsName, Description description, Guid unitId)
        {
            if (IngredientsName == ingredientsName && UnitId == unitId && Description == description) return;
            IngredientsName = ingredientsName;
            UnitId = unitId;
            Description = description;
            UpdatedAt = DateTimeOffset.UtcNow;
        }
    }
}