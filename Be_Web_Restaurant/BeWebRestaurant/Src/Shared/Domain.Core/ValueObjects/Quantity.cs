using Domain.Core.Base;
using Domain.Core.Messages;
using Domain.Core.Rule;
using Domain.Core.Rule.NumberRule;

namespace Domain.Core.ValueObjects
{
    public sealed class Quantity<T> : ValueObject where T : struct, IComparable
    {
        public T Value { get; }

        protected override IEnumerable<Object> GetAtomicValues()
        {
            yield return Value;
        }

        public Quantity(T value)
        {
            Value = value;
        }

        public static Quantity<T> Create(T value)
        {
            RuleValidator.CheckRules(new IBusinessRule[]
            {
                new NotNegativeRule<T>(value,FieldNames.Quantity,Errors.QuantityMustNotBeNegative)
            });
            return new Quantity<T>(value);
        }
    }
}