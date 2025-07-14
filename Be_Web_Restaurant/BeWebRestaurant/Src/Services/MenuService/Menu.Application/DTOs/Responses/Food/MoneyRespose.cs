using Menu.Domain.Enums;

namespace Menu.Application.DTOs.Responses.Food
{
    public sealed record MoneyRespose(decimal Amount, CurrencyEnum Currency)
    {
    }
}