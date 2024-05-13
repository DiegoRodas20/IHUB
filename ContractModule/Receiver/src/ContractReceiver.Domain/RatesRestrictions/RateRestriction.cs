using ContractReceiver.Domain.ExtraRates;
using ContractReceiver.Domain.Offers;
using ContractReceiver.Domain.Shared.Entities;

namespace ContractReceiver.Domain.RatesRestrictions;

public class RateRestriction : RateRestrictionBase
{
    public decimal AmountBeforeTax { get; private set; }
    public decimal AmountAfterTax { get; private set; }
    public int MLOS { get; private set; }
    public int Release { get; private set; }

    private RateRestriction(
        decimal amountBeforeTax,
        decimal amountAfterTax,
        int mLOS,
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
        AmountBeforeTax = amountBeforeTax;
        AmountAfterTax = amountAfterTax;
        MLOS = mLOS;
        Release = release;
    }

    public static Result<RateRestriction> Create(
        dynamic amountBeforeTax,
        dynamic amountAfterTax,
        dynamic mlos,
        dynamic release,
        dynamic baseOccupancy,
        dynamic isPerRoom,
        List<ExtraRate> clientExtraRates,
        List<Offer> offers,
        List<Offer> offerInfo,
        dynamic room,
        dynamic start,
        dynamic end,
        dynamic mealPlan)
    {

        if (release == null)
        {
            return Result.Failure<RateRestriction>(RateRestrictionErrors.NullOrEmpty(nameof(Release)));
        }

        if (mlos == null)
        {
            return Result.Failure<RateRestriction>(RateRestrictionErrors.NullOrEmpty(nameof(MLOS)));
        }

        if (amountBeforeTax == null)
        {
            return Result.Failure<RateRestriction>(RateRestrictionErrors.NullOrEmpty(nameof(AmountBeforeTax)));
        }

        var result = new RateRestriction(
            (decimal)amountBeforeTax,
            (decimal)amountAfterTax,
            (int)mlos,
            (int)release,
            (int)baseOccupancy,
            (bool)isPerRoom,
            clientExtraRates,
            offers,
            offerInfo,
            (int)room,
            (DateTime)start,
            (DateTime)end,
            (int)mealPlan);

        return result;
    }
}
