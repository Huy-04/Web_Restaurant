using Menu.Domain.Rules.FoodTypeRule.NameFoodType;

namespace MenuService.UnitTests.FoodTypeTests
{
    public class NameFoodTypeTest
    {
        [Theory]
        [InlineData("Pizza", true)]
        [InlineData("12345678901234567890123456789012345678901234567890", true)] // 50 ký tự
        [InlineData("123456789012345678901234567890123456789012345678901", false)] // 51 ký tự
        public void IsMaxLength(string name, bool expctedResult)
        {
            var rule = new NameFoodTypeMaxLength(name);

            var result = rule.IsSatisfied();

            Assert.Equal(expctedResult, result);
        }

        [Theory]
        [InlineData("Pizza", true)]
        [InlineData("", false)]
        [InlineData("   ", false)]
        [InlineData(null, false)]
        public void IsEmpty(string name, bool expctedResult)
        {
            var rule = new NameFoodTypeNotEmpty(name);

            var result = rule.IsSatisfied();

            Assert.Equal(expctedResult, result);
        }
    }
}
