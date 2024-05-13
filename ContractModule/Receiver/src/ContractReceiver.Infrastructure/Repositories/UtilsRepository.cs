//using Azure.Storage.Blobs;
//using ContractReceiver.Domain.Contracts;
//using ContractReceiver.Domain.Shared.Repository;
//using ContractReceiver.Domain.Shared;
//using ContractReceiver.Domain.Shared.Entities;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Logging;
//using System.Text;
//using System.Text.Json;

//namespace ContractReceiver.Infrastructure.Repositories;

//public class UtilsRepository(ILogger<ContractRepository> log, IConfiguration configuration)
//    : IUtilsRepository
//{
//    private const string STORAGE_CONNECTION = "AzureWebJobsStorage";
//    private const string CONTAINER_FAILED_BLOB = "freceiver_failed_blob";

//    public async Task<string> GetBlobStorage(string blobPath, string? contractBlobContainer)
//    {
//        var blobClient = await CreateBlobClient(blobPath, contractBlobContainer);

//        using MemoryStream memoryStream = new();
//        _ = blobClient.DownloadToAsync(memoryStream);
//        var json = Encoding.UTF8.GetString(memoryStream.ToArray());

//        return json;
//    }

//    public async Task<bool> UploadBlobStorage(Contract contract)
//    {
//        var filePath = Methods.FilePathCreate(contract.Id);
//        var blobClient = await CreateBlobClient(filePath);

//        using MemoryStream stream = new(Methods.ContractToByteString(contract).ToByteArray());
//        return blobClient.UploadAsync(stream, true).IsCompletedSuccessfully;
//    }

//    public Task SaveErrorLog(Result result)
//    {
//        var message = JsonSerializer.Serialize(result);
//        log.LogError(message);
//        return Task.FromResult(true);
//    }

//    private async Task<BlobClient> CreateBlobClient(string blobPath, string? contractBlobContainer = "")
//    {
//        //TODO: metodo asincrono sin await
//        var blobServiceClient = new BlobServiceClient(configuration[STORAGE_CONNECTION]);
//        var containerClient = blobServiceClient.GetBlobContainerClient(contractBlobContainer);
//        return containerClient.GetBlobClient(blobPath);
//    }
//}
