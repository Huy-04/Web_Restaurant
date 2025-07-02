using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Base;
using Domain.Core.Rule;
using Domain.Core.RuleException;
using Menu.Domain.Enums;
using Menu.Domain.Rules.Common.Factories;
using Menu.Domain.Rules.Common.Message;
using Menu.Domain.Rules.Common.Message.ErroMessages;
using Menu.Domain.Rules.Common.Message.FieldNames;

namespace Menu.Domain.ValueObjects
{
    public class Money : ValueObject
    {
        public decimal Amount { get; }
        public CurrencyEnum Currency { get; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Amount;
            yield return Currency;
        }

        private Money(decimal amount, CurrencyEnum currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public static Money Create(decimal amount, CurrencyEnum currency)
        {
            RuleValidator.CheckRules(new IBusinessRule[] {
                FoodRuleFactory.CurrencyValidate(currency),
                FoodRuleFactory.PriceNotNegative(amount)
            });

            switch (currency)
            {
                case CurrencyEnum.USD:
                    amount = decimal.Round(amount, 2, MidpointRounding.AwayFromZero);
                    break;

                case CurrencyEnum.VND:
                    amount = decimal.Round(amount, 0, MidpointRounding.AwayFromZero);
                    break;
            }

            return new Money(amount, currency);
        }

        public Money Add(Money other)
        {
            EnsureSameCurrency(other);
            return new Money(Amount + other.Amount, Currency);
        }

        public Money Subtract(Money other)
        {
            EnsureSameCurrency(other);
            decimal result = Amount - other.Amount;
            RuleValidator.CheckRules(new IBusinessRule[] {
                CommonRuleFactory.AmountNotNegative(result)
            });
            return new Money(result, Currency);
        }

        public Money Multiply(decimal factor)
        {
            RuleValidator.CheckRules(new IBusinessRule[]
            {
                CommonRuleFactory.FactorNotNegative(factor)
            });
            return new Money(Amount * factor, Currency);
        }

        private void EnsureSameCurrency(Money other)
        {
            RuleValidator.CheckRules(new IBusinessRule[]
            {
                FoodRuleFactory.CurrencyEqual(Currency,other.Currency)
            });
        }

        public static Money operator +(Money a, Money b) => a.Add(b);

        public static Money operator -(Money a, Money b) => a.Subtract(b);

        public static Money operator *(Money a, decimal factor) => a.Multiply(factor);

        public static Money operator *(decimal factor, Money a) => a.Multiply(factor);

        public override string ToString()
            => $"{Amount:0.##} {Currency}";
    }
}