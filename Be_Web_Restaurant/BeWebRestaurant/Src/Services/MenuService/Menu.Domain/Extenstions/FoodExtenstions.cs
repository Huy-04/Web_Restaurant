using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Menu.Domain.Enums;

namespace Menu.Domain.Extenstions
{
    public class FoodExtenstions
    {
        public static bool CanBeOrdered(FoodStatusEnum foodStatus) 
            => foodStatus == FoodStatusEnum.Available;

        public static bool NeedRestock(FoodStatusEnum foodStatus)
            => foodStatus == FoodStatusEnum.OutOfStock;
    }
}
