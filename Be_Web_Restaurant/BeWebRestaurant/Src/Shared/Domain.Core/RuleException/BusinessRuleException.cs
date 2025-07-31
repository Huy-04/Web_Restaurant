using Domain.Core.Enums;

namespace Domain.Core.RuleException
{
    public class BusinessRuleException : Exception
    {
        public ErrorCode ErrorCode { get; }

        public IEnumerable<string> Messages { get; }

        public string Field { get; }

        public BusinessRuleException(ErrorCode errorCode, string field, IEnumerable<string> messages)
            : base(string.Join(" | ", messages))
        {
            ErrorCode = errorCode;
            Field = field;
            Messages = messages;
        }
    }
}