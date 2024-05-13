using ContractReceiver.Domain.ExtraRates;
using ContractReceiver.Domain.Offers;
using ContractReceiver.Domain.Shared.Entities;

namespace ContractReceiver.Domain.Restrictions;

public class RestrictionBuilder
{
    public static Result<RateBase> CreateRestriction(dynamic clientRate)
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

        Result<Restriction> restrictionResult = Restriction.Create(
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

        return restrictionResult.IsFailure ? Result.Failure<RateBase>(restrictionResult.Error) : restrictionResult.Value;
    }
}
