using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Domain.Common.Message.ErrorMessages
{
    public static class FoodMessages
    {
        // IdFood
        public const string IdFoodNotFound = "IdFood Not Found";

        // FoodName
        public const string FoodNameMustNotBeEmpty = "Food name must not be empty";

        public const string FoodNameMaxLengthExceeded = "Food name must not exceed 50 characters";

        public const string FoodNameexisted = "Food name already exists";

        // Description
        public const string DescriptionMaxLengthExceeded = "Food description must not exceed 255 characters";

        public const string DescriptionNotBeEmpty = "Food description must not be empty";

        // Img
        public const string ImgMaxLengthExceeded = "Food Img must not exceed 255 characters";

        public const string ImgNotBeEmpty = "Food Img must not be empty";
    }
}