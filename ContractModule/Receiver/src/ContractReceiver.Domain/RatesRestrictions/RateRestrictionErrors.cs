using ContractReceiver.Domain.Shared.Entities;

namespace ContractReceiver.Domain.RatesRestrictions;

public static class RateRestrictionErrors
{
    public static Error NullOrEmpty(string attribute) => new(
        "RateRestriction.NullOrEmpty",
        $"Null or Empty attribute: {attribute}");
}