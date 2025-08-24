namespace Inventory.Domain.ValueObjects.Inventory
{
    public sealed class Capacity : QuantityBase<decimal, Capacity>
    {
        private Capacity(decimal value) : base(value)
        {
        }

        public static Capacity Create(decimal value)
        {
            return new Capacity(value);
        }

        protected override Capacity CreateCore(decimal value)
        {
            return Create(value);
        }
    }
}