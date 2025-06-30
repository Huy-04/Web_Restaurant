using Domain.Core.Rule;
using Menu.Domain.Common.Message;
using Menu.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Domain.Rules.FoodRule
{
    public class PriceRule : IBusinessRule
    {
        private readonly decimal _price;

        public string Field => FieldNames.Price;

        public PriceRule(decimal price)
        {
            _price = price;
        }

        public string Message => ErrorMessages.PriceMustNotBeNegative;

        public bool IsSatisfied() => _price >= 0;
    }
}
