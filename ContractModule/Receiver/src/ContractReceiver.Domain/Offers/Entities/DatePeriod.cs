using ContractReceiver.Domain.Contracts;
using ContractReceiver.Domain.Shared.Entities;

namespace ContractReceiver.Domain.Offers.Entities;

public class DatePeriod
{
    public DateTime Start { get; private set; }
    public DateTime End { get; private set; }

    private DatePeriod(
        DateTime start,
        DateTime end)
    {
        Start = start;
        End = end;
    }

    public static Result<DatePeriod> Create(dynamic start, dynamic end)
    {
        if (start == null)
        {
            return Result.Failure<DatePeriod>(ContractErrors.RequiredAttribute(nameof(Start)));
        }

        if (end == null)
        {
            return Result.Failure<DatePeriod>(ContractErrors.RequiredAttribute(nameof(End)));
        }

        var result = new DatePeriod((DateTime)start, (DateTime)end);

        return result;
    }
}
