using Domain.Core.Rule;
using Menu.Domain.Common.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Domain.Rules.FoodRule
{
    public class ImgMaxLength :IBusinessRule
    {
        private readonly string _img;

        public string Field => FieldNames.Img;

        public ImgMaxLength(string img)
        {
            _img = img;
        }

        public bool IsSatisfied() => _img?.Trim().Length <= 255;

        public string Message => ErrorMessages.ImgMaxLengthExceeded;
    }
}
