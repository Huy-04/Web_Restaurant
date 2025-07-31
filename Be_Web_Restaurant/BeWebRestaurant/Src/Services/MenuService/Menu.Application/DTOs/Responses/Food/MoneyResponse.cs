using Domain.Core.Enums;

namespace Menu.Application.DTOs.Responses.Food
{
    public sealed record MoneyResponse(decimal Amount, CurrencyEnum Currency)
    {
    }
}