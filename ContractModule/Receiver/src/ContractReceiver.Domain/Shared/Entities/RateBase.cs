namespace ContractReceiver.Domain.Shared.Entities;

public class RateBase
{
    public int Room { get; private set; }
    public DateTime Start { get; private set; }
    public DateTime End { get; private set; }
    public int MealPlan { get; private set; }

    protected RateBase(
        int room,
        DateTime start,
        DateTime end,
        int mealPlan)
    {
        Room = room;
        Start = start;
        End = end;
        MealPlan = mealPlan;
    }
}
