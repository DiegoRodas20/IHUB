using ContractReceiver.Domain.Shared.Entities;

namespace ContractReceiver.Domain.Allotments;

public class AllotmentBuilder
{
    public static Result<RateBase> CreateAllotment(dynamic clientRate)
    {
        Result<Allotment> allotmentResult = Allotment.Create(
            clientRate.Allotment,
            clientRate.PhysicalAllotment,
            clientRate.RoomCode,
            clientRate.StartDate,
            clientRate.EndDate,
            clientRate.MealPlan);

        if (allotmentResult.IsFailure)
        {
            return Result.Failure<RateBase>(allotmentResult.Error);
        }

        return allotmentResult.Value;
    }
}