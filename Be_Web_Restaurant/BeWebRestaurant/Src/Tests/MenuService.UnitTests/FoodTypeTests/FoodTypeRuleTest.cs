using Domain.Core.Rule;
using Domain.Core.RuleException;
using Menu.Domain.Entities;
using Menu.Domain.Rules.FoodTypeRule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuService.UnitTests.FoodTypeTests
{
    public class FoodTypeRuleTest
    {
        [Fact]
        public void FoodTypeRule_ValidName_ShouldNotThrowException()
        {
            var foodType = FoodType.Create("Pizza");

            var exception = Record.Exception(() => new FoodTypeRule(foodType));
            Assert.Null(exception); 
        }

        [Fact]
        public void FoodTypeRule_EmptyName_ShouldThrowException()
        {
            var foodType = FoodType.Create("");

            Assert.Throws<BusinessRuleException>(() => new FoodTypeRule(foodType));
        }

        [Fact]
        public void FoodTypeRule_WhiteSpaceName_ShouldThrowException()
        {
            var foodType = FoodType.Create("   ");

            Assert.Throws<BusinessRuleException>(() => new FoodTypeRule(foodType));
        }

        [Fact]
        public void FoodTypeRule_NameExceedMaxLength_ShouldThrowException()
        {
            var foodType = FoodType.Create(new string('a', 51)); // 51 ký tự

            Assert.Throws<BusinessRuleException>(() => new FoodTypeRule(foodType));
        }

    }
}
