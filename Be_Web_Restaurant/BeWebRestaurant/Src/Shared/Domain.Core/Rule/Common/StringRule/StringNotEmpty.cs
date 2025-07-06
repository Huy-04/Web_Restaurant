namespace Domain.Core.Rule.Common.StringRule
{
    public class StringNotEmpty : IBusinessRule
    {
        private readonly string _value;
        private readonly string _field;
        private readonly string _message;

        public StringNotEmpty(string value, string field, string message)
        {
            _value = value;
            _field = field;
            _message = message;
        }

        public bool IsSatisfied() => !string.IsNullOrEmpty(_value?.Trim());

        public string Field => _field;

        public string Message => _message;
    }
}