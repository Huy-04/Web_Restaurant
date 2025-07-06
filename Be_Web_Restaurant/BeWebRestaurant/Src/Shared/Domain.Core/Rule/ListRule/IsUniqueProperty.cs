namespace Domain.Core.Rule.ListRule
{
    public class IsUniqueProperty<T> : IBusinessRule
    {
        private readonly IEnumerable<T> _list;
        private readonly string _field;
        private readonly string _message;
        private readonly string _property;

        public IsUniqueProperty(IEnumerable<T> list, string field, string message, string property)
        {
            _list = list;
            _field = field;
            _message = message;
            _property = property;
        }

        public string Message => _message;

        public string Field => _field;

        public bool IsSatisfied()
        {
            var propertyInfo = typeof(T).GetProperty(_property);

            if (propertyInfo == null)
            {
                return false;
            }

            return _list.GroupBy(x => propertyInfo.GetValue(x)).All(g => g.Count() == 1);
        }
    }
}