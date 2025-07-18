using Domain.Core.RuleException;
using Domain.Core.RuleException.Errors;

namespace Domain.Core.Rule
{
    public static class RuleValidator
    {
        public static void CheckRules(IEnumerable<IBusinessRule> rules)
        {
            var broken = rules.Where(r => !r.IsSatisfied()).ToList();
            if (broken.Any())
            {
                throw new BusinessRuleException(ErrorCode.ValidationFailed,
                    broken.First().Field,
                    broken.Select(p => p.Message));
            }
        }
    }
}