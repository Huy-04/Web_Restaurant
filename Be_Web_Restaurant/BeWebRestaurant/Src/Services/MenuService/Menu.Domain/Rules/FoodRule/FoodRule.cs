using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Menu.Domain.ValueObjects;
using Menu.Domain.Entities;
using Menu.Domain.Rules;
using Menu.Domain.Rules.FoodRule.NameFood;
using Domain.Core.Rule;


namespace Menu.Domain.Rules.FoodRule
{
    public class FoodRule 
    {
        public FoodRule(Food food)
        {
            RuleValidator.CheckRules(new IBusinessRule[]
            {
                new NameFoodNotEmpty(food.NameFood),
                    new NameFoodMaxLength(food.NameFood),
                    new NameFoodNotEmpty(food.NameFood),
                    new FoodStatusRule(food.Status),
                    new CurrencyRule(food.Price.Currency),
                    new PriceRule(food.Price.Amount),
                    new DescriptionMaxLength(food.Description),
                    new ImgMaxLength(food.Img)
            });
        }
    }
}
