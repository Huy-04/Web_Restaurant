using Domain.Core.Base;
using Domain.Core.ValueObjects;
using Inventory.Domain.ValueObjects.Common;

namespace Inventory.Domain.Entities
{
    public sealed class FoodRecipe : AggregateRoot
    {
        public Guid FoodId { get; private set; }

        public Guid IngredientsId { get; private set; }

        public Quantity Quantity { get; private set; }

        public DateTimeOffset CreatedAt { get; private set; }

        public DateTimeOffset UpdatedAt { get; private set; }

        // for orm
        private FoodRecipe()
        {
        }

        private FoodRecipe(Guid id, Guid foodId, Guid ingredientsId, Quantity quantity) : base(id)
        {
            FoodId = foodId;
            IngredientsId = ingredientsId;
            Quantity = quantity;
            CreatedAt = UpdatedAt = DateTimeOffset.UtcNow;
        }

        public static FoodRecipe Create(Guid foodId, Guid ingredientsId, Quantity quantity)
        {
            var entity = new FoodRecipe(Guid.NewGuid(), foodId, ingredientsId, quantity);
            return entity;
        }

        public void Update(Guid foodId, Guid ingredientsId, Quantity quantity)
        {
            if (FoodId == foodId && IngredientsId == ingredientsId && Quantity == quantity) return;
            FoodId = foodId;
            IngredientsId = ingredientsId;
            Quantity = quantity;
            UpdatedAt = DateTimeOffset.UtcNow;
        }
    }
}