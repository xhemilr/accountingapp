using AccountingApp.Application.Interfaces.Common;

namespace AccountingApp.Application.Interfaces.Services
{
    public interface ICurrentUserService : IService
    {
        string UserId { get; }
    }
}