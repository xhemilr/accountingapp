using System.Linq;
using AccountingApp.Shared.Constants.Localization;
using AccountingApp.Shared.Settings;

namespace AccountingApp.Server.Settings
{
    public record ServerPreference : IPreference
    {
        public string LanguageCode { get; set; } = LocalizationConstants.SupportedLanguages.FirstOrDefault()?.Code ?? "en-US";

        //TODO - add server preferences
    }
}