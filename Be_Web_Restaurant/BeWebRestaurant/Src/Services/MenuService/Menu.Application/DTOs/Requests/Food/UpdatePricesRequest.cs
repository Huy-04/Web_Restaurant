namespace Menu.Application.DTOs.Requests.Food
{
    public sealed record UpdatePricesRequest(Guid IdFood, IReadOnlyCollection<MoneyRequest> Prices)
    {
    }
}