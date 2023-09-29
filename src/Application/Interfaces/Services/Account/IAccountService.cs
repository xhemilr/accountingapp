using AccountingApp.Application.Interfaces.Common;
using AccountingApp.Application.Requests.Identity;
using AccountingApp.Shared.Wrapper;
using System.Threading.Tasks;

namespace AccountingApp.Application.Interfaces.Services.Account
{
    public interface IAccountService : IService
    {
        Task<IResult> UpdateProfileAsync(UpdateProfileRequest model, string userId);

        Task<IResult> ChangePasswordAsync(ChangePasswordRequest model, string userId);

        Task<IResult<string>> GetProfilePictureAsync(string userId);

        Task<IResult<string>> UpdateProfilePictureAsync(UpdateProfilePictureRequest request, string userId);
    }
}