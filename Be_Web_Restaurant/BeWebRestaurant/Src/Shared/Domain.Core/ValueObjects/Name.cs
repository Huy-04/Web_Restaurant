using Domain.Core.Base;

namespace Domain.Core.ValueObjects
{
    public abstract class Name : ValueObject
    {
        public string Value { get; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        protected Name(string value)
        {
            Value = value;
        }

        public static implicit operator string(Name name) => name.Value;

        public override string ToString() => Value;
    }
}