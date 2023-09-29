using System.Threading.Tasks;
using AccountingApp.Application.Features.Dashboards.Queries.GetData;
using AccountingApp.Shared.Wrapper;

namespace AccountingApp.Client.Infrastructure.Managers.Dashboard
{
    public interface IDashboardManager : IManager
    {
        Task<IResult<DashboardDataResponse>> GetDataAsync();
    }
}