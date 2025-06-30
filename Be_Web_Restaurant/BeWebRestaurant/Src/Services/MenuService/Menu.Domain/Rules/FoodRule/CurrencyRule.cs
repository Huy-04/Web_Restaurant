using Domain.Core.Rule;
using Menu.Domain.Common.Message;
using Menu.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Domain.Rules.FoodRule
{
    public class CurrencyRule : IBusinessRule
    {
        private readonly Currency _currency;

        public string Field => FieldNames.Currency;

        public CurrencyRule(Currency currency)
        {
            _currency = currency;
        }

        public string Message => ErrorMessages.InvalidCurrencyValue;

        public bool IsSatisfied() =>
           _currency == Currency.USD || _currency == Currency.VND;
    }
}
