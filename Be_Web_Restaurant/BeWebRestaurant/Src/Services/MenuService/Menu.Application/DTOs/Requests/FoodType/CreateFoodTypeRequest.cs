using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Application.DTOs.Requests.FoodType
{
    public sealed record CreateFoodTypeRequest(string FoodTypeName)
    {
    }
}