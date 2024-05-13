using ContractReceiver.Domain.Shared.Entities;

namespace ContractReceiver.Domain.OpenCloses;

public static class OpenCloseErrors
{
    public static Error NullOrEmpty(string attribute) => new(
        "OpenClose.NullOrEmpty",
        $"Null or Empty attribute: {attribute}");
}