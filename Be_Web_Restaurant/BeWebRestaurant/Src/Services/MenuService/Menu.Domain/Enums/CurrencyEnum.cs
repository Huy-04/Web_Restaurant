using System.Text.Json.Serialization;

namespace Menu.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CurrencyEnum
    {
        VND = 1,
        USD = 2
    }
}