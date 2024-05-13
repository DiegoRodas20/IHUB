using ContractReceiver.Domain.Offers.Entities;
using ContractReceiver.Domain.Shared.Entities;

namespace ContractReceiver.Domain.Offers;

public class Offer
{
    public Guid Id { get; private set; }
    public string Code { get; private set; } = string.Empty;
    public string Name { get; private set; } = string.Empty;
    public List<Content> Contents { get; private set; }
    public List<DatePeriod> TravelPeriods { get; private set; }
    public List<DatePeriod> BookingWindows { get; private set; }

    private Offer(
        string code,
        string name,
        List<Content> contents,
        List<DatePeriod> travelPeriods,
        List<DatePeriod> bookingWindows)
    {
        Id = new Guid();
        Code = code;
        Name = name;
        Contents = contents;
        TravelPeriods = travelPeriods;
        BookingWindows = bookingWindows;
    }

    public static Result<Offer> Create(
        dynamic code,
        dynamic name,
        List<Content> contents,
        List<DatePeriod> travelPeriods,
        List<DatePeriod> bookingWindows)
    {

        if (code == null)
        {
            return Result.Failure<Offer>(OfferErrors.NullOrEmpty(nameof(Code)));
        }

        if (name == null)
        {
            return Result.Failure<Offer>(OfferErrors.NullOrEmpty(nameof(Name)));
        }

        var result = new Offer(
            (string)code,
            (string)name,
            contents,
            travelPeriods,
            bookingWindows);

        return result;
    }
}
