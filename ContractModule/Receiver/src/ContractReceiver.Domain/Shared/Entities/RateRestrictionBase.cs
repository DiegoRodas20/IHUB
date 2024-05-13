using ContractReceiver.Domain.ExtraRates;
using ContractReceiver.Domain.Offers;

namespace ContractReceiver.Domain.Shared.Entities;

public class RateRestrictionBase : RateBase
{
    public int BaseOccupancy { get; private set; }
    public bool IsPerRoom { get; private set; }
    public List<ExtraRate> ClientExtraRates { get; private set; }
    public List<Offer> Offers { get; private set; }
    public List<Offer> OffersInfo { get; private set; }

    protected RateRestrictionBase(
        int baseOccupancy,
        bool isPerRoom,
        List<ExtraRate> clientExtraRates,
        List<Offer> offers,
        List<Offer> offersInfo,
        int room,
        DateTime start,
        DateTime end,
        int mealPlan)
        : base(room, start, end, mealPlan)
    {
        BaseOccupancy = baseOccupancy;
        IsPerRoom = isPerRoom;
        ClientExtraRates = clientExtraRates;
        Offers = offers;
        OffersInfo = offersInfo;
    }
}
