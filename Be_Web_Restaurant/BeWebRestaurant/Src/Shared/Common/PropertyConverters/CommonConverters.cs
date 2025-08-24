using Domain.Core.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;

namespace Common.PropertyConverters
{
    public static class CommonConverters
    {
        public static readonly ValueConverter<Description, string>
            DescriptionConverter = new(v => v.Value, v => Description.Create(v));

        public static readonly ValueConverter<Img, string>
            ImgConverter = new(v => v.Value, v => Img.Create(v));

        public static readonly ValueConverter<PriceList, string>
          PriceListConverter = new(v => JsonSerializer.Serialize(v.Items, (JsonSerializerOptions?)null),
             v => PriceList.Create(JsonSerializer.Deserialize<IEnumerable<Money>>(v, (JsonSerializerOptions?)null)!));
    }
}