using ContractReceiver.Domain.Shared.Entities;

namespace ContractReceiver.Domain.Restrictions;

public static class RestrictionErrors
{
    public static Error NullOrEmpty(string attribute) => new(
        "Restriction.NullOrEmpty",
        $"Null or Empty attribute: {attribute}");
}