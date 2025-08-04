using Domain.Core.Base;
using Domain.Core.Rule;
using Domain.Core.ValueObjects;
using Inventory.Domain.Common.Factories.Rule;

namespace Inventory.Domain.ValueObjects.Unit
{
    public sealed class UnitName : Name
    {
        private UnitName(string value) : base(value)
        {
            RuleValidator.CheckRules(new IBusinessRule[]
           {
                UnitRuleFactory.NameMaxLength(value),
                UnitRuleFactory.NameNotEmpty(value)
           });
        }

        public static UnitName Create(string value)
        {
            return new UnitName(value);
        }
    }
}