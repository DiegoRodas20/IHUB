using ContractReceiver.Domain.Shared.Entities;

namespace ContractReceiver.Domain.Contracts;

public class SystemRequest
{
    public Guid ReturnAddress { get; private set; }
    public string SecurityHash { get; private set; } = string.Empty;

    private SystemRequest(Guid returnAddress,
                          string securityHash)
    {
        ReturnAddress = returnAddress;
        SecurityHash = securityHash;
    }

    public static Result<SystemRequest> Create(
        dynamic returnAddress,
        dynamic securityHash)
    {
        if (returnAddress == null)
        {
            return Result.Failure<SystemRequest>(ContractErrors.RequiredAttribute(nameof(ReturnAddress)));
        }

        if (securityHash == null)
        {
            return Result.Failure<SystemRequest>(ContractErrors.RequiredAttribute(nameof(SecurityHash)));
        }

        var result = new SystemRequest(
            (Guid)returnAddress,
            (string)securityHash);

        return result;
    }
}