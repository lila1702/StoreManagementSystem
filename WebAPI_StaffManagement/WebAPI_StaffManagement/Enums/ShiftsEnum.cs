using System.Text.Json.Serialization;

namespace WebAPI_StoreManagement.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ShiftsEnum
    {
        Manhã,
        Tarde,
        Noite
    }
}
