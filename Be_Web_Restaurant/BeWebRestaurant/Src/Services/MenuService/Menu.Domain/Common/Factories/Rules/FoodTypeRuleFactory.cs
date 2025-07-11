﻿using Domain.Core.Rule;
using Domain.Core.Rule.Common.StringRule;
using Menu.Domain.Common.Message.ErroMessages;
using Menu.Domain.Common.Message.FieldNames;

namespace Menu.Domain.Common.Factories.Rules
{
    public static class FoodTypeRuleFactory
    {
        // FoodTypeName
        public static IBusinessRule NameMaxLength(string value)
        {
            return new StringMaxLength(value, 50, FoodTypeField.NameFoodType, FoodTypeMessages.FoodTypeNameMaxLengthExceeded);
        }

        public static IBusinessRule NameNotEmpty(string value)
        {
            return new StringNotEmpty(value, FoodTypeField.NameFoodType, FoodTypeMessages.FoodTypeNameMustNotBeEmpty);
        }
    }
}