using AccountingApp.Application.Interfaces.Common;
using AccountingApp.Application.Requests.Identity;
using AccountingApp.Application.Responses.Identity;
using AccountingApp.Shared.Wrapper;
using System.Threading.Tasks;

namespace AccountingApp.Application.Interfaces.Services.Identity
{
    public interface ITokenService : IService
    {
        Task<Result<TokenResponse>> LoginAsync(TokenRequest model);

        Task<Result<TokenResponse>> GetRefreshTokenAsync(RefreshTokenRequest model);
    }
}