namespace Domain.Core.Rule
{
    public class SimpleBusinessRule : IBusinessRule
    {
        public string Field { get; }
        public string Message { get; }

        public SimpleBusinessRule(string field, string message)
        {
            Field = field;
            Message = message;
        }

        public bool IsSatisfied() => false;
    }
}