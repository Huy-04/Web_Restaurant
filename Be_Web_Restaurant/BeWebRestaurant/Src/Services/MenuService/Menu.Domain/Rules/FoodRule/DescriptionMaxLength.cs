using Domain.Core.Rule;
using Menu.Domain.Common.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Domain.Rules.FoodRule
{
    public class DescriptionMaxLength : IBusinessRule   
    {
        private readonly string _description;

        public string Field => FieldNames.Description;

        public DescriptionMaxLength(string description)
        {
            _description = description;
        }

        public bool IsSatisfied() => _description?.Trim().Length <= 255;

        public string Message => ErrorMessages.DescriptionMaxLengthExceeded;
    }
}
