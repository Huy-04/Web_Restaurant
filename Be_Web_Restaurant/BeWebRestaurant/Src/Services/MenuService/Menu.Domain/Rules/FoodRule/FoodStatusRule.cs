
using Domain.Core.Rule;
using Menu.Domain.Common.Message;
using Menu.Domain.Enums;

namespace Menu.Domain.Rules.FoodRule
{
    public class FoodStatusRule : IBusinessRule
    {
        private readonly FoodStatus _foodstatus;

        public string Field => FieldNames.FoodStatus;

        public FoodStatusRule(FoodStatus foodStatus)
        {
            _foodstatus = foodStatus;
        }

        public string Message => ErrorMessages.InvalidFoodStatusValue;

        public bool IsSatisfied()
        => _foodstatus == FoodStatus.Available
        || _foodstatus == FoodStatus.Discontinued
        || _foodstatus == FoodStatus.OutOfStock;


    }
}
