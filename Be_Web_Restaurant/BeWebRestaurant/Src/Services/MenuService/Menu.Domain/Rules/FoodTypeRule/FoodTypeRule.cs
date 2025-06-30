using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Rule;
using Menu.Domain.Entities;
using Menu.Domain.Rules;
using Menu.Domain.Rules.FoodRule.NameFood;
using Menu.Domain.Rules.FoodRule;
using Menu.Domain.Rules.FoodTypeRule.NameFoodType;


namespace Menu.Domain.Rules.FoodTypeRule
{
    public class FoodTypeRule 
    {
        public FoodTypeRule(FoodType foodtype)
        {
            RuleValidator.CheckRules(new IBusinessRule[]
            {
                new NameFoodTypeNotEmpty(foodtype.NameFoodType),
                new NameFoodTypeMaxLength(foodtype.NameFoodType)
            });
        }
    }
}
