using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Base;
using Domain.Core.Rule;
using Domain.Core.RuleException;
using Menu.Domain.Common.Message;
using Menu.Domain.Enums;
using Menu.Domain.Rules.FoodRule;

namespace Menu.Domain.ValueObjects
{
    public class Money : ValueObject
    {
        public decimal Amount { get; }
        public Currency Currency { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            yield return Currency;
        }

        private Money(decimal amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public static Money Of(decimal amount, Currency currency)
        {
            RuleValidator.CheckRules(new IBusinessRule[] {
                new PriceRule(amount),
                new CurrencyRule(currency)
            });

            switch (currency)
            {
                case Currency.USD:
                    amount = decimal.Round(amount, 2, MidpointRounding.AwayFromZero);
                    break;
                case Currency.VND:
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
                new PriceRule(result),
            });
            return new Money(result, Currency);
        }

        public Money Multiply(decimal factor)
        {
            if (factor < 0)
                throw new BusinessRuleException(new[]
                {new SimpleBusinessRule(FieldNames.Factor, ErrorMessages.FactorMustNotBeNegative)});
            return new Money(Amount * factor, Currency);
        }

        private void EnsureSameCurrency(Money other)
        {
            if (Currency != other.Currency)
                throw new BusinessRuleException(new[]
                { new SimpleBusinessRule(FieldNames.Currency, ErrorMessages.CurrencyMismatchError)});
        }

        public static Money operator +(Money a, Money b) => a.Add(b);
        public static Money operator -(Money a, Money b) => a.Subtract(b);
        public static Money operator *(Money a, decimal factor) => a.Multiply(factor);
        public static Money operator *(decimal factor, Money a) => a.Multiply(factor);

        public override string ToString()
            => $"{Amount:0.##} {Currency}";

    }
}
