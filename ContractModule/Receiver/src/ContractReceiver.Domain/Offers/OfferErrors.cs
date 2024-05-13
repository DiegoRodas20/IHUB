using ContractReceiver.Domain.Shared.Entities;

namespace ContractReceiver.Domain.Offers;

public static class OfferErrors
{
    public static Error NullOrEmpty(string attribute) => new(
        "Offer.NullOrEmpty",
        $"Null or Empty attribute: {attribute}");
}