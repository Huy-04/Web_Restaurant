using Domain.Core.Enums;
using Domain.Core.RuleException;

namespace Domain.Core.Rule.RuleFactory
{
    public static class RuleFactory
    {
        public static BusinessRuleException SimpleRuleException(ErrorCode errorCode, string field, IEnumerable<string> messages)
        {
            var dict = new Dictionary<string, List<string>>
            {
                [field] = messages.ToList()
            };
            return new BusinessRuleException(errorCode, dict);
        }
    }
}