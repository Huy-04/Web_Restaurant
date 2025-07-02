using Domain.Core.Rule;
using Domain.Core.Rule.Common.StringRule;
using Menu.Domain.Rules.Common.Message;
using Menu.Domain.Rules.Common.Message.ErroMessages;
using Menu.Domain.Rules.Common.Message.FieldNames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Domain.Rules.Common.Factories
{
    public static class FoodTypeRuleFactory
    {
        // FoodTypeName
        public static IBusinessRule NameMaxLength(string value)
                => new StringMaxLength(value, 50, FoodTypeField.NameFoodType, FoodTypeMessages.FoodTypeNameMaxLengthExceeded);

        public static IBusinessRule NameNotEmpty(string value)
            => new StringNotEmpty(value, FoodTypeField.NameFoodType, FoodTypeMessages.FoodTypeNameMustNotBeEmpty);
    }
}