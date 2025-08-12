using Domain.Core.Enums;

namespace Common.DTOs.Requests
{
    public sealed record MoneyRequest(decimal Amount, CurrencyEnum CurrencyEnum)
    {
    }
}