using Domain.Core.Enums;

namespace Domain.Core.RuleException
{
    public class BusinessRuleException : Exception
    {
        public ErrorCode ErrorCode { get; }

        // Key = Field, Value = Danh sách lỗi của field đó
        public IReadOnlyDictionary<string, List<string>> Errors { get; }

        public BusinessRuleException(
            ErrorCode errorCode,
            IReadOnlyDictionary<string, List<string>> errors)
            : base(string.Join(" | ", errors.SelectMany(e => e.Value)))
        {
            ErrorCode = errorCode;
            Errors = errors;
        }
    }
}