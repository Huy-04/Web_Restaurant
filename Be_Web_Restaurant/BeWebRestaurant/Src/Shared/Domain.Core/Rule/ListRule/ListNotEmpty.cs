namespace Domain.Core.Rule.ListRule
{
    public class ListNotEmpty<T> : IBusinessRule
    {
        private readonly IEnumerable<T> _list;
        private readonly string _message;
        private readonly string _field;

        public ListNotEmpty(IEnumerable<T> list, string field, string message)
        {
            _list = list;
            _field = field;
            _message = message;
        }

        public string Message => _message;

        public string Field => _field;

        public bool IsSatisfied() => _list != null && _list.Any();
    }
}