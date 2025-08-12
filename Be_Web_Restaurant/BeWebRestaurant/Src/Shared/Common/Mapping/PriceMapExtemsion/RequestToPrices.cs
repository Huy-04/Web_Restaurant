using Common.DTOs.Requests;
using Domain.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Mapping.PriceMapExtemsion
{
    public static class RequestToPrices
    {
        public static Money ToMoney(this MoneyRequest request)
        {
            return Money.Create(request.Amount, request.CurrencyEnum);
        }

        public static PriceList ToPrices(this IReadOnlyCollection<MoneyRequest> request)
        {
            return PriceList.Create(request.Select(money => money.ToMoney()));
        }
    }
}