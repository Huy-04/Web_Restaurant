using Domain.Core.Base;
using Menu.Domain.ValueObjects.FoodType;

namespace Menu.Domain.Entities
{
    public sealed class FoodType : AggregateRoot
    {
        public FoodTypeName FoodTypeName { get; private set; }

        public DateTimeOffset CreatedAt { get; private set; }

        public DateTimeOffset UpdatedAt { get; private set; }

        private FoodType()
        { }

        private FoodType(Guid id, FoodTypeName foodTypeName)
            : base(id)
        {
            FoodTypeName = foodTypeName;
            CreatedAt = UpdatedAt = DateTimeOffset.UtcNow;
        }

        public static FoodType Create(FoodTypeName foodTypeName)
        {
            var entity = new FoodType(Guid.NewGuid(), foodTypeName);
            return entity;
        }

        public void UpdateName(FoodTypeName foodTypeName)
        {
            FoodTypeName = foodTypeName;
            UpdatedAt = DateTimeOffset.UtcNow;
        }
    }
}