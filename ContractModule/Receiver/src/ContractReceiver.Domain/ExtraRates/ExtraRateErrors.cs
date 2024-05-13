using ContractReceiver.Domain.Shared.Entities;

namespace ContractReceiver.Domain.ExtraRates;

public static class ExtraRateErrors
{
    public static Error NullOrEmpty(string attribute) => new(
        "ExtraRate.NullOrEmpty",
        $"Null or Empty attribute: {attribute}");
}