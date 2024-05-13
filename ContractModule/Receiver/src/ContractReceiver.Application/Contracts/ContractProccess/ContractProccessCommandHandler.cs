using ContractReceiver.Application.Abstractions.Messaging;
using ContractReceiver.Domain.Contracts;
using ContractReceiver.Domain.Shared.Repository;
using ContractReceiver.Domain.Shared.Entities;
using System.Text.Json;

namespace ContractReceiver.Application.Contracts.ContractProccess;

internal sealed class ContractProccessCommandHandler(
    IUtilsRepository utilsRepository,
    IContractRepository contractRepository)
    : ICommandHandler<ContractProccessCommand>
{
    public async Task<Result> Handle(ContractProccessCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.BlobPath))
        {
            return ContractErrors.InvalidBlobPath(request.BlobPath);
        }

        var contractBlob = await utilsRepository.GetBlobStorage(request.BlobPath, request.ReservationContainer);

        if (string.IsNullOrEmpty(contractBlob))
        {
            return ContractErrors.NullOrEmpty(request.BlobPath);
        }

        var dynamicContract = JsonSerializer.Deserialize<List<dynamic>>(contractBlob);

        Result<Contract> contract = ContractBuilder.CreateContract(dynamicContract![0]);

        if (contract.IsFailure)
        {
            return ContractErrors.InvalidConstruction(request.BlobPath);
        }

        var isSent = await SendContract(contract.Value);

        return !isSent ? ContractErrors.NotSent(request.BlobPath) : Result.Success();
    }

    private async Task<bool> SendContract(Contract contract)
    {
        return (ContractType)contract.Type switch
        {
            ContractType.Rates => await contractRepository.SendContractRate(contract),
            ContractType.Restrictions => await contractRepository.SendContractRestriction(contract),
            ContractType.Allotment => await contractRepository.SendContractAllotment(contract),
            ContractType.OpenClose => await contractRepository.SendContractOpenClose(contract),
            ContractType.RatesAndRestrictions => await contractRepository.SendContractRateRestriction(contract),
            _ => await utilsRepository.UploadBlobStorage(contract)
        };
    }
}