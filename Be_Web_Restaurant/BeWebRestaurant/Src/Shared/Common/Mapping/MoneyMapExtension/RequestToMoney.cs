using Common.DTOs.Requests;
using Domain.Core.ValueObjects;

namespace Common.Mapping.MoneyMapExtension
{
    public static class RequestToMoney
    {
        public static Money ToMoney(this MoneyRequest request)
        {
            return Money.Create(request.Amount, request.CurrencyEnum);
        }
    }
}