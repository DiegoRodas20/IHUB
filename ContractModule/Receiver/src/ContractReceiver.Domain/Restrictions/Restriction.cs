using ContractReceiver.Domain.Contracts;
using ContractReceiver.Domain.ExtraRates;
using ContractReceiver.Domain.Offers;
using ContractReceiver.Domain.Shared.Entities;

namespace ContractReceiver.Domain.Restrictions;

public class Restriction : RateRestrictionBase
{
    public int MLOS { get; private set; }
    public int Release { get; private set; }

    private Restriction(
        int mlos,
        int release,
        int baseOccupancy,
        bool isPerRoom,
        List<ExtraRate> clientExtraRates,
        List<Offer> offers,
        List<Offer> offersInfo,
        int room,
        DateTime start,
        DateTime end,
        int mealPlan)
        : base(baseOccupancy, isPerRoom, clientExtraRates, offers, offersInfo, room, start, end, mealPlan)
    {
        MLOS = mlos;
        Release = release;
    }

    public static Result<Restriction> Create(
        dynamic mlos,
        dynamic release,
        dynamic baseOccupancy,
        dynamic isPerRoom,
        List<ExtraRate> clientExtraRates,
        List<Offer> offers,
        List<Offer> offersInfo,
        dynamic room,
        dynamic start,
        dynamic end,
        dynamic mealPlan)
    {
        if (mlos == null)
        {
            return Result.Failure<Restriction>(RestrictionErrors.NullOrEmpty(nameof(MLOS)));
        }

        if (release == null)
        {
            return Result.Failure<Restriction>(RestrictionErrors.NullOrEmpty(nameof(Release)));
        }

        var result = new Restriction(
            (int)mlos,
            (int)release,
            (int)baseOccupancy,
            (bool)isPerRoom,
            clientExtraRates,
            offers,
            offersInfo,
            (int)room,
            (DateTime)start,
            (DateTime)end,
            (int)mealPlan);

        return result;
    }

}
