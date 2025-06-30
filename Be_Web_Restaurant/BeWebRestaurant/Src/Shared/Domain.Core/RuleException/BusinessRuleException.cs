using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Core.Rule;

namespace Domain.Core.RuleException
{
    public class BusinessRuleException : Exception
    {
        public IEnumerable<IBusinessRule> Rules { get; }

        public List<string> Messages { get; }

        public Dictionary<string, List<string>> ErrorByField { get; }

        public BusinessRuleException(IEnumerable<IBusinessRule> rules)
            : base()
        {
            Rules = rules;
            Messages = rules.Select(r => r.Message).ToList();
            ErrorByField = rules
                .GroupBy(static s => s.Field)
                .ToDictionary(
                g => g.Key,
                g => g.Select(r => r.Message).ToList()
                );
        }
    }
}
