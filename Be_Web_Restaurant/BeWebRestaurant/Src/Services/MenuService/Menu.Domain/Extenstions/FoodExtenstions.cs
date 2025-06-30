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
        public static bool CanBeOrdered(FoodStatus foodStatus) 
            => foodStatus == FoodStatus.Available;

        public static bool NeedRestock(FoodStatus foodStatus)
            => foodStatus == FoodStatus.OutOfStock;
    }
}
