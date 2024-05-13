using ContractReceiver.Domain.Shared.Entities;

namespace ContractReceiver.Domain.Allotments;

public class Allotment : RateBase
{
    public int AllotmentValue { get; private set; }
    public int PhysicalAllotment { get; private set; }

    private Allotment(
        int allotmentValue,
        int physicalAllotment,
        int room,
        DateTime start,
        DateTime end,
        int mealPlan)
        : base(room, start, end, mealPlan)
    {
        AllotmentValue = allotmentValue;
        PhysicalAllotment = physicalAllotment;
    }

    public static Result<Allotment> Create(
        dynamic allotment,
        dynamic physicalAllotment,
        dynamic room,
        dynamic start,
        dynamic end,
        dynamic mealPlan)
    {

        if (allotment == null)
        {
            return Result.Failure<Allotment>(AllotmentErrors.NullOrEmpty(nameof(AllotmentValue)));
        }

        if (physicalAllotment == null)
        {
            return Result.Failure<Allotment>(AllotmentErrors.NullOrEmpty(nameof(PhysicalAllotment)));
        }

        var result = new Allotment(
            (int)allotment,
            (int)physicalAllotment,
            (int)room,
            (DateTime)start,
            (DateTime)end,
            (int)mealPlan);

        return result;
    }
}
