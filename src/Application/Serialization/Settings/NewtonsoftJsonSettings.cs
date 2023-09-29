
using AccountingApp.Application.Interfaces.Serialization.Settings;
using Newtonsoft.Json;

namespace AccountingApp.Application.Serialization.Settings
{
    public class NewtonsoftJsonSettings : IJsonSerializerSettings
    {
        public JsonSerializerSettings JsonSerializerSettings { get; } = new();
    }
}