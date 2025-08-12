using Domain.Core.ValueObjects;
using Inventory.Domain.ValueObjects.Ingredients;

namespace Inventory.Application.DTOs.Requests.Ingredients
{
    public sealed record IngredientsRequest(
        string IngredientsName,
        Guid UnitId,
        string Description)
    {
    }
}