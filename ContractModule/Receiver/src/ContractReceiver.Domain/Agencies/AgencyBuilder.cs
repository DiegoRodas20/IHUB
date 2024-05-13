using ContractReceiver.Domain.Contracts;
using ContractReceiver.Domain.Rates;
using ContractReceiver.Domain.Shared.Entities;

namespace ContractReceiver.Domain.Agencies;

public class AgencyBuilder
{
    public static Result<List<Agency>> CreateAgencies(dynamic agencies, ContractType type)
    {
        List<Agency> agenciesResult = [];

        foreach (var agency in agencies)
        {
            var agenciesId = CreateAgenciesId(agency);

            Result<List<RateBase>> clientRatesResult = RateBuilder.CreateClientRates(agency.ClientRates, type);

            if (clientRatesResult.IsFailure)
            {
                return Result.Failure<List<Agency>>(clientRatesResult.Error);
            }

            Result<Agency> agencyResult = Agency.Create(
                agenciesId,
                clientRatesResult.Value);

            if (agencyResult.IsFailure)
            {
                return Result.Failure<List<Agency>>(agencyResult.Error);
            }

            agenciesResult.Add(agencyResult.Value);
        }

        return agenciesResult;
    }

    private static List<int> CreateAgenciesId(dynamic agency)
    {
        List<int> agenciesId = [];

        foreach (var agencyId in agency.OriginalIds)
        {
            agenciesId.Add((int)agencyId);
        }

        return agenciesId;
    }

}
