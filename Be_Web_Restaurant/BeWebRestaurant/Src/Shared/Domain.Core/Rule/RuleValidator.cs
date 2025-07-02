using Domain.Core.RuleException;

namespace Domain.Core.Rule
{
    public static class RuleValidator
    {
        public static void CheckRules(IEnumerable<IBusinessRule> rules)
        {
            var violatedRules = rules.Where(r => !r.IsSatisfied()).ToList();
            if (violatedRules.Any())
            {
                throw new BusinessRuleException(violatedRules);
            }
        }
    }
}