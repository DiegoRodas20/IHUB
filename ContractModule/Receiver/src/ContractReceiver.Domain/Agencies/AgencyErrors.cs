using ContractReceiver.Domain.Shared.Entities;

namespace ContractReceiver.Domain.Agencies;

public static class AgencyErrors
{
    public static Error NullOrEmpty(string attribute) => new(
        "Agency.NullOrEmpty",
        $"Null or Empty attribute: {attribute}");
}