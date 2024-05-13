using ContractReceiver.Domain.Allotments;
using ContractReceiver.Domain.Contracts;
using ContractReceiver.Domain.ExtraRates;
using ContractReceiver.Domain.Offers;
using ContractReceiver.Domain.OpenCloses;
using ContractReceiver.Domain.RatesRestrictions;
using ContractReceiver.Domain.Restrictions;
using ContractReceiver.Domain.Shared.Entities;

namespace ContractReceiver.Domain.Rates;

public class RateBuilder
{
    public static Result<List<RateBase>> CreateClientRates(dynamic clientRates, ContractType type)
    {
        List<RateBase> clientRatesResult = [];

        foreach (var clientRate in clientRates)
        {
            Result<RateBase> rateResult = CreateClientRate(type, clientRate);

            if (rateResult.IsFailure)
            {
                return Result.Failure<List<RateBase>>(rateResult.Error);
            }

            clientRatesResult.Add(rateResult.Value);
        }

        return clientRatesResult;
    }

    public static Result<RateBase> CreateClientRate(ContractType contractType, dynamic clientRate)
    {
        return contractType switch
        {
            ContractType.Rates => CreateRate(clientRate),
            ContractType.Restrictions => RestrictionBuilder.CreateRestriction(clientRate),
            ContractType.Allotment => AllotmentBuilder.CreateAllotment(clientRate),
            ContractType.OpenClose => OpenCloseBuilder.CreateOpenClose(clientRate),
            ContractType.RatesAndRestrictions => RateRestrictionBuilder.CreateRateRestriction(clientRate),
            _ => Result.Failure<RateBase>(ContractErrors.InvalidType(contractType))
        };
    }

    public static Result<RateBase> CreateRate(dynamic clientRate)
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

        Result<Rate> rateResult = Rate.Create(
            clientRate.AmountBeforeTax,
            clientRate.AmountAfterTax,
            clientRate.RoomBaseOccupancy,
            clientRate.IsPerRoom,
            clientExtraRates.Value,
            offers.Value,
            offersInfo.Value,
            clientRate.RoomCode,
            clientRate.StartDate,
            clientRate.EndDate,
            clientRate.MealPlan);

        if (rateResult.IsFailure)
        {
            return Result.Failure<RateBase>(rateResult.Error);
        }

        return rateResult.Value;
    }

}