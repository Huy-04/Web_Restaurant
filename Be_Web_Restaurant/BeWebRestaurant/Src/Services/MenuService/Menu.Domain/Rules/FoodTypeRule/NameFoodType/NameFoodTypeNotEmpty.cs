using Domain.Core.Rule;
using Menu.Domain.Common.Message;
using Menu.Domain.Rules;

namespace Menu.Domain.Rules.FoodTypeRule.NameFoodType
{
    public class NameFoodTypeNotEmpty : IBusinessRule
    {
        private readonly string _name;
        public string Field => FieldNames.NameFoodType;
        public NameFoodTypeNotEmpty(string name)
        {
            _name = name;
        }

        public bool IsSatisfied() => !string.IsNullOrEmpty(_name?.Trim());
        public string Message => ErrorMessages.FoodTypeNameMustNotBeEmpty;
    }
}