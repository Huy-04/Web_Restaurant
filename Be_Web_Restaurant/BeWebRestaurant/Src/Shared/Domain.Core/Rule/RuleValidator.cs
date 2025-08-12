using Domain.Core.Enums;
using Domain.Core.RuleException;

namespace Domain.Core.Rule
{
    public static class RuleValidator
    {
        public static void CheckRules(IEnumerable<IBusinessRule> rules)
        {
            var broken = rules.Where(r => !r.IsSatisfied()).ToList();
            if (broken.Any())
            {
                var dict = broken
                    .GroupBy(r => r.Field)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Select(r => r.Message).ToList());

                throw new BusinessRuleException(ErrorCode.ValidationFailed, dict);
            }
        }
    }
}