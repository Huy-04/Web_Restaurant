using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Rule.Common.EnumRule
{
    public class EnumValidateRule<TEnum> : IBusinessRule where TEnum : Enum
    {
        private readonly TEnum _value;
        private readonly IEnumerable<TEnum> _validate;
        private readonly string _field;
        private readonly string _message;

        public EnumValidateRule(TEnum value, IEnumerable<TEnum> validValues, string field, string message)
        {
            _value = value;
            _validate = validValues;
            _field = field;
            _message = message;
        }

        public string Field => _field;

        public string Message => _message;

        public bool IsSatisfied() => _validate.Contains(_value);
    }
}