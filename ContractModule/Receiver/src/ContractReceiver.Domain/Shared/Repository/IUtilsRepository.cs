using ContractReceiver.Domain.Contracts;
using ContractReceiver.Domain.Shared.Entities;

namespace ContractReceiver.Domain.Shared.Repository;

public interface IUtilsRepository
{
    Task<string> GetBlobStorage(string blobPath, string? contractBlobContainer);
    Task<bool> UploadBlobStorage(Contract contract);
    Task SaveErrorLog(Result result);
}
