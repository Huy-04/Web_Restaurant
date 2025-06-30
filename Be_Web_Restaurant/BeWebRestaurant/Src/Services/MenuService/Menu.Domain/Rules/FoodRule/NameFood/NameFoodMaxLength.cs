using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Rule;
using Menu.Domain.Common.Message;

namespace Menu.Domain.Rules.FoodRule.NameFood
{
    public class NameFoodMaxLength : IBusinessRule
    {
        private readonly string _name;

        public string Field => FieldNames.NameFood;

        public NameFoodMaxLength(string name)
        {
            _name = name;
        }

        public bool IsSatisfied() => _name?.Trim().Length <= 50;

        public string Message => ErrorMessages.FoodNameMaxLengthExceeded;
    }
}
