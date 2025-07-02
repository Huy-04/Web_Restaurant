using Domain.Core.Base;
using Domain.Core.Rule;
using Menu.Domain.Rules.Common.Factories;

namespace Menu.Domain.ValueObjects
{
    public sealed class Img : ValueObject
    {
        public string Value { get; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        private Img(string value)
        {
            Value = value;
        }

        public static Img Create(string value)
        {
            RuleValidator.CheckRules(new IBusinessRule[]
            {
                FoodRuleFactory.ImgMaxLength(value),
                FoodRuleFactory.ImgNotEmpty(value)
            });
            return new Img(value);
        }

        public static implicit operator string(Img img) => img.Value;

        public override string ToString() => Value;
    }
}