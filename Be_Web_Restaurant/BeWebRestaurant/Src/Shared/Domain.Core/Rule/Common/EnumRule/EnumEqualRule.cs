using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Rule.Common.EnumRule
{
    public class EnumEqualRule<TEnum> : IBusinessRule where TEnum : Enum
    {
        private readonly TEnum _left;
        private readonly TEnum _right;
        private readonly string _field;
        private readonly string _message;

        public EnumEqualRule(TEnum left, TEnum right, string field, string message)
        {
            _left = left;
            _right = right;
            _field = field;
            _message = message;
        }

        public string Field => _field;

        public string Message => _message;

        public bool IsSatisfied() => _left.Equals(_right);
    }
}