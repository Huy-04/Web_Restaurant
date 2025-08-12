using Domain.Core.Enums;

namespace Common.DTOs.Responses
{
    public sealed record MoneyResponse(decimal Amount, CurrencyEnum CurrencyEnum)
    {
    }
}