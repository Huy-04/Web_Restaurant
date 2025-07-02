using Domain.Core.Rule;
using Domain.Core.Rule.Common;
using Menu.Domain.Rules.Common.Message.ErroMessages;
using Menu.Domain.Rules.Common.Message.FieldNames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Domain.Rules.Common.Factories
{
    public static class CommonRuleFactory
    {
        public static IBusinessRule FactorNotNegative(decimal factor)
        {
            return new NotNegativeRule<decimal>(factor, CommonField.Factor, CommonMessages.FactorMustNotBeNegative);
        }

        public static IBusinessRule AmountNotNegative(decimal amount)
        {
            return new NotNegativeRule<decimal>(amount, CommonField.Amount, CommonMessages.AmountMustNotBeNegative);
        }
    }
}