using ContractReceiver.Domain.Hotels;
using ContractReceiver.Domain.Shared.Entities;

namespace ContractReceiver.Domain.Contracts;

public class ContractBuilder
{
    public static Result<Contract> CreateContract(dynamic contract)
    {
        dynamic systemRequest = contract.ReturnService[0];

        Result<SystemRequest> systemRequestResult = SystemRequest.Create(
            systemRequest.ReturnAddress,
            systemRequest.SecurityHash);

        if (systemRequestResult.IsFailure)
        {
            return Result.Failure<Contract>(systemRequestResult.Error);
        }

        Result<List<Hotel>> hotelsResult = HotelBuilder.CreateHotels(
            contract.Hotels,
            (ContractType)contract.UpdateType);

        if (hotelsResult.IsFailure)
        {
            return Result.Failure<Contract>(hotelsResult.Error);
        }

        Result<Contract> contractResult = Contract.Create(
            contract.Currency,
            contract.CreationDate,
            contract.ModificationDate,
            contract.UpdateType,
            systemRequestResult.Value,
            hotelsResult.Value);

        if (contractResult.IsFailure)
        {
            return Result.Failure<Contract>(contractResult.Error);
        }

        return contractResult;
    }

}