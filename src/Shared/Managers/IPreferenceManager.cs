using System.Threading.Tasks;
using AccountingApp.Shared.Settings;
using AccountingApp.Shared.Wrapper;

namespace AccountingApp.Shared.Managers
{
    public interface IPreferenceManager
    {
        Task SetPreference(IPreference preference);

        Task<IPreference> GetPreference();

        Task<IResult> ChangeLanguageAsync(string languageCode);
    }
}