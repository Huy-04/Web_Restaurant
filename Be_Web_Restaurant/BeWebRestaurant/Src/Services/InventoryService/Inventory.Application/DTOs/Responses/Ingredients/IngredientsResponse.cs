namespace Inventory.Application.DTOs.Responses.Ingredients
{
    public sealed record IngredientsResponse(
        Guid IdIngredients,
        string IngredientsName,
        Guid UnitId,
        string Description,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt)
    {
    }
}