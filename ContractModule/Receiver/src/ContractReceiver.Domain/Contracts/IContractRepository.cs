namespace ContractReceiver.Domain.Contracts;

public interface IContractRepository
{
    Task<bool> SendContractRate(Contract contract);
    Task<bool> SendContractRestriction(Contract contract);
    Task<bool> SendContractRateRestriction(Contract contract);
    Task<bool> SendContractAllotment(Contract contract);
    Task<bool> SendContractOpenClose(Contract contract);
}
