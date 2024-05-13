using ContractReceiver.Domain.Shared.Entities;

namespace ContractReceiver.Domain.Allotments;

public static class AllotmentErrors
{
    public static Error NullOrEmpty(string attribute) => new(
        "Allotment.NullOrEmpty",
        $"Null or Empty attribute: {attribute}");
}