using Menu.Domain.Enums;
using Menu.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;

namespace Menu.Infrastructure.Persistence.EntityConfigurations
{
    public static class Converters
    {
        public static readonly ValueConverter<FoodName, string>
            FoodNameConverter = new(v => v.Value, v => FoodName.Create(v));

        public static readonly ValueConverter<FoodTypeName, string>
            FoodTypeNameConverter = new(v => v.Value, v => FoodTypeName.Create(v));

        public static readonly ValueConverter<Description, string>
            DescriptionConverter = new(v => v.Value, v => Description.Create(v));

        public static readonly ValueConverter<Img, string>
            ImgConverter = new(v => v.Value, v => Img.Create(v));

        public static readonly ValueConverter<FoodStatus, int>  
            FoodStatusConverter = new(v => (int)v.Value, v => FoodStatus.Create((FoodStatusEnum)v));

        public static readonly ValueConverter<PriceList, string>
            PriceListConverter = new(v => JsonSerializer.Serialize(v.Items, (JsonSerializerOptions?)null),
               v => PriceList.Create(JsonSerializer.Deserialize<IEnumerable<Money>>(v, (JsonSerializerOptions?)null)!));
    }
}