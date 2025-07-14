using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Application.DTOs.Responses.FoodType
{
    public sealed record FoodTypeResponse(
        Guid IdFoodType,
        string FoodTypeName,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt)
    {
    }
}