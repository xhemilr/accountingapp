using AccountingApp.Client.Infrastructure.Managers;
using System.Threading.Tasks;
using Toolbelt.Blazor;

namespace AccountingApp.Client.Infrastructure.Managers.Interceptors
{
    public interface IHttpInterceptorManager : IManager
    {
        void RegisterEvent();

        Task InterceptBeforeHttpAsync(object sender, HttpClientInterceptorEventArgs e);

        void DisposeEvent();
    }
}