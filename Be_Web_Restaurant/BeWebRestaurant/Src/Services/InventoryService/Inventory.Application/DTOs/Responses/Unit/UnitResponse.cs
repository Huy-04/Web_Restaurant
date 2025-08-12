namespace Inventory.Application.DTOs.Responses.Unit
{
    public sealed record UnitResponse(
        Guid IdUnit,
        string UnitName,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt)
    {
    }
}