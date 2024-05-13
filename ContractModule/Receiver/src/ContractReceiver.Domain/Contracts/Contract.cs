using ContractReceiver.Domain.Hotels;
using ContractReceiver.Domain.Shared.Entities;

namespace ContractReceiver.Domain.Contracts;

public class Contract
{
    public Guid Id { get; private set; }
    public string Currency { get; private set; } = string.Empty;
    public DateTime Creation { get; private set; }
    public DateTime Modification { get; private set; }
    public int Type { get; private set; }
    public SystemRequest Request { get; private set; }
    public List<Hotel> Hotels { get; private set; }

    private Contract(
        Guid id,
        string currency,
        DateTime creation,
        DateTime modification,
        int type,
        SystemRequest request,
        List<Hotel> hotels)
    {
        Id = id;
        Currency = currency;
        Creation = creation;
        Modification = modification;
        Type = type;
        Request = request;
        Hotels = hotels;
    }

    public static Result<Contract> Create(
        dynamic currency,
        dynamic creation,
        dynamic modification,
        dynamic type,
        SystemRequest request,
        List<Hotel> hotels)
    {
        if (currency == null)
        {
            return Result.Failure<Contract>(ContractErrors.RequiredAttribute(nameof(Currency)));
        }

        if (type == null)
        {
            return Result.Failure<Contract>(ContractErrors.RequiredAttribute(nameof(Type)));
        }

        var result = new Contract(
            Guid.NewGuid(),
            (string)currency,
            (DateTime)creation,
            (DateTime)modification,
            (int)type,
            request,
            hotels);

        return result;
    }
}