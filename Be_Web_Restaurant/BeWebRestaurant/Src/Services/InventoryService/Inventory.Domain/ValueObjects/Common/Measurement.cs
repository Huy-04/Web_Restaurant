using Domain.Core.Base;
using Domain.Core.Rule;
using Inventory.Domain.Common.Factories.Rule;
using Inventory.Domain.Enums;
using Inventory.Domain.Extension;

namespace Inventory.Domain.ValueObjects.Common
{
    public sealed class Measurement : ValueObject
    {
        public decimal Value { get; }

        public UnitEnum Unit { get; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
            yield return Unit;
        }

        private Measurement(decimal value, UnitEnum unit)
        {
            Value = value;
            Unit = unit;
        }

        public static Measurement Create(decimal value, UnitEnum unit)
        {
            RuleValidator.CheckRules(new IBusinessRule[]
            {
                MeasurementRuleFactory.ValueNotNegative(value),
                MeasurementRuleFactory.UnitValidate(unit)
            });

            value = decimal.Round(value, 2, MidpointRounding.AwayFromZero);

            return new Measurement(value, unit);
        }

        public Measurement Add(Measurement other)
        {
            if (Unit != other.Unit)
            {
                other = other.ConvertTo(Unit);
            }
            return Create(Value + other.Value, Unit);
        }

        public Measurement Subtract(Measurement other)
        {
            if (Unit != other.Unit)
            {
                other = other.ConvertTo(Unit);
            }
            return Create(Value - other.Value, Unit);
        }

        public static Measurement operator +(Measurement a, Measurement b) => a.Add(b);

        public static Measurement operator -(Measurement a, Measurement b) => a.Subtract(b);

        public override string ToString() => $"{Value:0.##} {Unit}";
    }
}