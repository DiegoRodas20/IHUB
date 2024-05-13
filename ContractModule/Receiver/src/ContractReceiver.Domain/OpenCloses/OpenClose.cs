using ContractReceiver.Domain.Shared.Entities;

namespace ContractReceiver.Domain.OpenCloses;

public class OpenClose : RateBase
{
    public bool IsBlackOut { get; private set; }

    private OpenClose(
        bool isBlackOut,
        int room,
        DateTime start,
        DateTime end,
        int mealPlan)
        : base(room, start, end, mealPlan)
    {
        IsBlackOut = isBlackOut;
    }

    public static Result<OpenClose> Create(
        dynamic isBlackOut,
        dynamic room,
        dynamic start,
        dynamic end,
        dynamic mealPlan)
    {

        if (isBlackOut == null)
        {
            return Result.Failure<OpenClose>(OpenCloseErrors.NullOrEmpty(nameof(IsBlackOut)));
        }

        var result = new OpenClose(
            (bool)isBlackOut,
            (int)room,
            (DateTime)start,
            (DateTime)end,
            (int)mealPlan);

        return result;
    }
}
