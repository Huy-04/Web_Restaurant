using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Domain.Rules.Common.Message.ErroMessages
{
    public static class FoodTypeMessages
    {
        public const string FoodTypeIdMustNotBeNegative = "Food type ID must not be negative";
        public const string FoodTypeNameMustNotBeEmpty = "Food type name must not be empty";
        public const string FoodTypeNameMaxLengthExceeded = "Food type name must not exceed 50 characters";
    }
}
