using Domain.Core.Rule.Common.EnumRule;
using Domain.Core.Rule;
using Menu.Domain.Common.Message.ErroMessages;
using Menu.Domain.Common.Message.FieldNames;
using Menu.Domain.Enums;

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