using ContractReceiver.Domain.Agencies;
using ContractReceiver.Domain.Contracts;
using ContractReceiver.Domain.Shared.Entities;

namespace ContractReceiver.Domain.Hotels;

public class HotelBuilder
{
    public static Result<List<Hotel>> CreateHotels(dynamic hotels, ContractType type)
    {
        List<Hotel> hotelsResult = [];

        foreach (var hotel in hotels)
        {
            Result<List<Agency>> agenciesResult = AgencyBuilder.CreateAgencies(hotel.Clients, type);

            if (agenciesResult.IsFailure)
            {
                return Result.Failure<List<Hotel>>(agenciesResult.Error);
            }

            Result<Hotel> hotelResult = Hotel.Create(
                hotel.HotelCode,
                hotel.DateType,
                hotel.RateType,
                hotel.ContractCode,
                agenciesResult.Value);

            if (hotelResult.IsFailure)
            {
                return Result.Failure<List<Hotel>>(hotelResult.Error);
            }

            hotelsResult.Add(hotelResult.Value);
        }

        return hotelsResult;
    }
}
