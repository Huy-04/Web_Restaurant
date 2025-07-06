namespace Domain.Core.Rule.Common.StringRule
{
    public class StringMaxLength : IBusinessRule
    {
        private readonly string _value;
        private readonly string _field;
        private readonly string _message;
        private readonly int _maxlength;

        public StringMaxLength(string value, int maxlength, string field, string message)
        {
            _value = value;
            _field = field;
            _message = message;
            _maxlength = maxlength;
        }

        public bool IsSatisfied() => _value?.Trim().Length <= _maxlength;

        public string Field => _field;

        public string Message => _message;
    }
}