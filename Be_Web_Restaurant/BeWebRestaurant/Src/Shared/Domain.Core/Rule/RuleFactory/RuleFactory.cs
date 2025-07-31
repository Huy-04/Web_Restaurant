using Domain.Core.Enums;
using Domain.Core.RuleException;

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