using ContractReceiver.Domain.ExtraRates;
using ContractReceiver.Domain.Offers;
using ContractReceiver.Domain.Shared.Entities;

namespace ContractReceiver.Domain.Rates;

public class Rate : RateRestrictionBase
{
    public double AmountBeforeTax { get; private set; }
    public double AmountAfterTax { get; private set; }

    private Rate(
        double amountBeforeTax,
        double amountAfterTax,
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
    }

    public static Result<Rate> Create(
        dynamic amountBeforeTax,
        dynamic amountAfterTax,
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
        if (amountBeforeTax == null)
        {
            return Result.Failure<Rate>(RateErrors.NullOrEmpty(nameof(AmountBeforeTax)));
        }

        if (amountAfterTax == null)
        {
            return Result.Failure<Rate>(RateErrors.NullOrEmpty(nameof(AmountAfterTax)));
        }

        var result = new Rate(
            (double)amountBeforeTax,
            (double)amountAfterTax,
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
