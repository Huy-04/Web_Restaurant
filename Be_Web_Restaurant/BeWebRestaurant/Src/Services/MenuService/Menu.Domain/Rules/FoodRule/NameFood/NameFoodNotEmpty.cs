using System.Net;
using Domain.Core.Rule;
using Menu.Domain.Common.Message;
using Menu.Domain.Rules;

namespace Menu.Domain.Rules.FoodRule.NameFood
{
    public class NameFoodNotEmpty : IBusinessRule
    {
        private readonly string _name;

        public string Field => FieldNames.NameFood;

        public NameFoodNotEmpty(string name)
        {
            _name = name;
        }

        public bool IsSatisfied() => !string.IsNullOrEmpty(_name?.Trim());

        public string Message => ErrorMessages.FoodNameMustNotBeEmpty;
    }

}

