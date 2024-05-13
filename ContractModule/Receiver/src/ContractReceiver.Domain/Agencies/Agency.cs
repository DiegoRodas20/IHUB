using ContractReceiver.Domain.Shared.Entities;

namespace ContractReceiver.Domain.Agencies;

public class Agency
{
    public List<int> AgencyIds { get; private set; }
    public List<RateBase> AgencyRates { get; private set; }

    private Agency(
        List<int> agencyIds,
        List<RateBase> agencyRates)
    {
        AgencyIds = agencyIds;
        AgencyRates = agencyRates;
    }

    public static Result<Agency> Create(
        List<int> agencyIds,
        List<RateBase> agencyRates)
    {
        if (agencyIds.Count == 0)
        {
            return Result.Failure<Agency>(AgencyErrors.NullOrEmpty(nameof(AgencyIds)));
        }

        if (agencyRates.Count == 0)
        {
            return Result.Failure<Agency>(AgencyErrors.NullOrEmpty(nameof(AgencyRates)));
        }

        var result = new Agency(agencyIds, agencyRates);

        return result;
    }
}
