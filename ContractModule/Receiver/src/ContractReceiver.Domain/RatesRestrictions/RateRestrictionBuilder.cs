using ContractReceiver.Domain.ExtraRates;
using ContractReceiver.Domain.Offers;
using ContractReceiver.Domain.Shared.Entities;

namespace ContractReceiver.Domain.RatesRestrictions;

public class RateRestrictionBuilder
{
    public static Result<RateBase> CreateRateRestriction(dynamic clientRate)
    {
        Result<List<ExtraRate>> clientExtraRates = ExtraRatesBuilder.CreateExtraRate(clientRate.ClientExtraRates);

        if (clientExtraRates.IsFailure)
        {
            return Result.Failure<RateBase>(clientExtraRates.Error);
        }

        Result<List<Offer>> offers = OfferBuilder.CreateOffers(clientRate.Offers);

        if (offers.IsFailure)
        {
            return Result.Failure<RateBase>(offers.Error);
        }

        Result<List<Offer>> offersInfo = OfferBuilder.CreateOffers(clientRate.OffersInfo);

        if (offersInfo.IsFailure)
        {
            return Result.Failure<RateBase>(offersInfo.Error);
        }

        Result<RateRestriction> rateRestrictionResult = RateRestriction.Create(
            clientRate.AmountBeforeTax,
            clientRate.AmountAfterTax,
            clientRate.MLOS,
            clientRate.Release,
            clientRate.RoomBaseOccupancy,
            clientRate.IsPerRoom,
            clientExtraRates.Value,
            offers.Value,
            offersInfo.Value,
            clientRate.RoomCode,
            clientRate.StartDate,
            clientRate.EndDate,
            clientRate.MealPlan);

        if (rateRestrictionResult.IsFailure)
        {
            return Result.Failure<RateBase>(rateRestrictionResult.Error);
        }

        return rateRestrictionResult.Value;
    }
}
