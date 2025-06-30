using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Base;

namespace Menu.Domain.Entities
{
    public class FoodType : Entity
    {
        public string NameFoodType { get; private set; }

        public virtual ICollection<Food> Foods { get; private set; } = new List<Food>();

        private FoodType() { }

        public FoodType(string nameFoodType)
        {
            NameFoodType = nameFoodType;
        }

        public static FoodType Create(string nameFoodType)
        {

            return new FoodType(nameFoodType);
        }

        public void UpdateName(string nameFoodType)
        {
            NameFoodType = nameFoodType;
        }

    }
}
