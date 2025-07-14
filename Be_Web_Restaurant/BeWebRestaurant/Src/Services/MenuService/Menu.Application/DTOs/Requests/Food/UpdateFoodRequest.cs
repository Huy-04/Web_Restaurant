using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Application.DTOs.Requests.Food
{
    public sealed record UpdateFoodRequest(
        Guid IdFood,
        string FoodName,
        Guid FoodTypeId,
        string Img,
        string Description,
        IReadOnlyCollection<MoneyRequest> Prices)
    {
    }
}