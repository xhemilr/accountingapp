using System.Text.Json;
using AccountingApp.Application.Interfaces.Serialization.Options;

namespace AccountingApp.Application.Serialization.Options
{
    public class SystemTextJsonOptions : IJsonSerializerOptions
    {
        public JsonSerializerOptions JsonSerializerOptions { get; } = new();
    }
}