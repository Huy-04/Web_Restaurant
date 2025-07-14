using Menu.Domain.Enums;

namespace Menu.Application.DTOs.Requests.Food
{
    public sealed record MoneyRequest(decimal Amount, CurrencyEnum Currency)
    {
    }
}