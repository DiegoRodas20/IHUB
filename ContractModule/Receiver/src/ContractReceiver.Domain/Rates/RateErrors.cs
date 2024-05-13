using ContractReceiver.Domain.Shared.Entities;

namespace ContractReceiver.Domain.Rates;

public static class RateErrors
{
    public static Error NullOrEmpty(string attribute) => new(
        "Rate.NullOrEmpty",
        $"Null or Empty attribute: {attribute}");
}