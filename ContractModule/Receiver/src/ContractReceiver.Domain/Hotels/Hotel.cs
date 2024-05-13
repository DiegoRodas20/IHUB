using ContractReceiver.Domain.Agencies;
using ContractReceiver.Domain.Shared.Entities;

namespace ContractReceiver.Domain.Hotels;

public class Hotel
{
    public int Id { get; private set; }
    public string DateType { get; private set; }
    public string RateType { get; private set; }
    public string Rate { get; private set; } 
    public List<Agency> Agencies { get; private set; }

    private Hotel(
        int id,
        string dateType,
        string rateType,
        string rate,
        List<Agency> agencies)
    {
        Id = id;
        DateType = dateType;
        RateType = rateType;
        Rate = rate;
        Agencies = agencies;
    }

    public static Result<Hotel> Create(
        dynamic id,
        dynamic dateType,
        dynamic rateType,
        dynamic rate,
        List<Agency> agencies)
    {
        if (id == null)
        {
            return Result.Failure<Hotel>(HotelErrors.NullOrEmpty(nameof(Id)));
        }

        if (dateType == null)
        {
            return Result.Failure<Hotel>(HotelErrors.NullOrEmpty(nameof(DateType)));
        }

        if (rateType == null)
        {
            return Result.Failure<Hotel>(HotelErrors.NullOrEmpty(nameof(RateType)));
        }

        var result = new Hotel(
            (int)id,
            (string)dateType,
            (string)rateType,
            (string)rate,
            agencies);

        return result;
    }
}
