namespace Domain.Core.Rule.NumberRule
{
    public class NotNegativeRule<T> : IBusinessRule where T : struct, IComparable
    {
        private readonly T _value;
        private readonly string _field;
        private readonly string _message;

        public NotNegativeRule(T value, string field, string message)
        {
            _value = value;
            _field = field;
            _message = message;
        }

        public string Field => _field;

        public string Message => _message;

        public bool IsSatisfied() => _value.CompareTo(default(T)) >= 0;
    }
}