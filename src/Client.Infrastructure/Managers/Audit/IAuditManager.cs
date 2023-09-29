using AccountingApp.Shared.Wrapper;
using AccountingApp.Application.Responses.Audit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountingApp.Client.Infrastructure.Managers.Audit
{
    public interface IAuditManager : IManager
    {
        Task<IResult<IEnumerable<AuditResponse>>> GetCurrentUserTrailsAsync();

        Task<IResult<string>> DownloadFileAsync(string searchString = "", bool searchInOldValues = false, bool searchInNewValues = false);
    }
}