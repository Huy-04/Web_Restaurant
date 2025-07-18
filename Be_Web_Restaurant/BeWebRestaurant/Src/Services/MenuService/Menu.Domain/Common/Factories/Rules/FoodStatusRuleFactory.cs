using Domain.Core.Rule;
using Menu.Domain.Common.Message.ErrorMessages;
using Menu.Domain.Common.Message.FieldNames;
using Menu.Domain.Enums;
using Domain.Core.Rule.EnumRule;

namespace Menu.Domain.Common.Factories.Rules
{
    public static class FoodStatusRuleFactory
    {
        public static IBusinessRule FoodStatusValidate(FoodStatusEnum foodstatus)
        {
            var validate = Enum.GetValues(typeof(FoodStatusEnum)).Cast<FoodStatusEnum>().ToList();
            return new EnumValidateRule<FoodStatusEnum>(foodstatus, validate, FoodStatusField.FoodStatus, FoodStatusMessages.InvalidFoodStatusValue);
        }
    }
}