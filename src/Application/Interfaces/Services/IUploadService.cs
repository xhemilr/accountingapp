using AccountingApp.Application.Requests;

namespace AccountingApp.Application.Interfaces.Services
{
    public interface IUploadService
    {
        string UploadAsync(UploadRequest request);
    }
}