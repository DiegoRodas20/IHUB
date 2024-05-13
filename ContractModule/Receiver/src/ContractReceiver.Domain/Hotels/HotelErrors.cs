using ContractReceiver.Domain.Shared.Entities;

namespace ContractReceiver.Domain.Hotels;

public static class HotelErrors
{
    public static Error NullOrEmpty(string attribute) => new(
        "Hotel.NullOrEmpty",
        $"Null or Empty attribute: {attribute}");
}
