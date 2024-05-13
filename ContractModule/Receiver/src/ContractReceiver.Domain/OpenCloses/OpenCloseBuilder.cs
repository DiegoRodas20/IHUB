using ContractReceiver.Domain.Shared.Entities;

namespace ContractReceiver.Domain.OpenCloses;

public class OpenCloseBuilder
{
    public static Result<RateBase> CreateOpenClose(dynamic clientRate)
    {
        Result<OpenClose> openCloseResult = OpenClose.Create(
            clientRate.IsBlackOut,
            clientRate.RoomCode,
            clientRate.StartDate,
            clientRate.EndDate,
            clientRate.MealPlan);

        if (openCloseResult.IsFailure)
        {
            return Result.Failure<RateBase>(openCloseResult.Error);
        }

        return openCloseResult.Value;
    }
}