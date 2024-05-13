using ContractReceiver.Domain.Offers.Entities;
using ContractReceiver.Domain.Shared.Entities;

namespace ContractReceiver.Domain.Offers;

public class OfferBuilder
{
    public static Result<List<Offer>> CreateOffers(dynamic offers)
    {
        List<Offer> offersResult = [];

        foreach (var offer in offers)
        {
            Result<List<Content>> contentResult = CreateContent(offer);

            if (contentResult.IsFailure)
            {
                return Result.Failure<List<Offer>>(contentResult.Error);
            }

            Result<List<DatePeriod>> travelPeriodsResult = CreateDatePeriods(offer.TravelPeriods);

            if (travelPeriodsResult.IsFailure)
            {
                return Result.Failure<List<Offer>>(travelPeriodsResult.Error);
            }

            Result<List<DatePeriod>> bookingWindowResult = CreateDatePeriods(offer.BookingWindow);

            if (travelPeriodsResult.IsFailure)
            {
                return Result.Failure<List<Offer>>(bookingWindowResult.Error);
            }

            Result<Offer> offerResult = Offer.Create(
                offer.Code,
                offer.Name,
                contentResult.Value,
                travelPeriodsResult.Value,
                bookingWindowResult.Value);

            if (offerResult.IsFailure)
            {
                return Result.Failure<List<Offer>>(offerResult.Error);
            }

            offersResult.Add(offerResult.Value);
        }

        return offersResult;
    }

    private static Result<List<Content>> CreateContent(dynamic offer)
    {
        List<Content> contents = [];

        foreach (var content in offer.Contents)
        {
            Result<Content> contentResult = Content.Create(
                content.Language,
                content.Name,
                content.Title,
                content.Text);

            if (contentResult.IsFailure)
            {
                return Result.Failure<List<Content>>(contentResult.Error);
            }

            contents.Add(contentResult.Value);
        }

        return contents;
    }

    private static Result<List<DatePeriod>> CreateDatePeriods(dynamic datePeriods)
    {
        List<DatePeriod> datePeriodsResult = [];

        foreach (var datePeriod in datePeriods)
        {
            Result<DatePeriod> datePeriodResult = DatePeriod.Create(
                datePeriod.StartDate,
                datePeriod.EndDate);

            if (datePeriodResult.IsFailure)
            {
                return Result.Failure<List<DatePeriod>>(datePeriodResult.Error);
            }

            datePeriodsResult.Add(datePeriodResult.Value);
        }

        return datePeriodsResult;
    }
}