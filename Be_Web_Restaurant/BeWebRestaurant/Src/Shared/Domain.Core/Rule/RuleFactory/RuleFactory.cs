using Domain.Core.RuleException;
using Domain.Core.RuleException.Errors;

namespace Domain.Core.Rule.RuleFactory
{
    public static class RuleFactory
    {
        public static BusinessRuleException SimpleRuleException(ErrorCode errorCode, string field, IEnumerable<string> messages)
        {
            return new BusinessRuleException(errorCode, field, messages);
        }
    }
}