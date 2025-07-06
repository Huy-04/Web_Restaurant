using Menu.Domain.Enums;
using Menu.Domain.ValueObjects;

namespace Menu.Domain.Common.Factories.Catalog
{
    public static class FoodStatusCatalog
    {
        public static FoodStatus Available => FoodStatusEnum.Available;
        public static FoodStatus OutOfStock => FoodStatusEnum.OutOfStock;
        public static FoodStatus Discontinued => FoodStatusEnum.Discontinued;
    }
}