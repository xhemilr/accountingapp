using System.Collections.Generic;
using System.Threading.Tasks;
using AccountingApp.Application.Interfaces.Common;
using AccountingApp.Application.Requests.Identity;
using AccountingApp.Application.Responses.Identity;
using AccountingApp.Shared.Wrapper;

namespace AccountingApp.Application.Interfaces.Services.Identity
{
    public interface IRoleClaimService : IService
    {
        Task<Result<List<RoleClaimResponse>>> GetAllAsync();

        Task<int> GetCountAsync();

        Task<Result<RoleClaimResponse>> GetByIdAsync(int id);

        Task<Result<List<RoleClaimResponse>>> GetAllByRoleIdAsync(string roleId);

        Task<Result<string>> SaveAsync(RoleClaimRequest request);

        Task<Result<string>> DeleteAsync(int id);
    }
}