using ContractReceiver.Domain.Shared.Entities;

namespace ContractReceiver.Domain.ExtraRates;

public class ExtraRate
{
    public int Type { get; private set; }
    public int PaxOrder { get; private set; }
    public decimal AmountBeforeTax { get; private set; }
    public decimal AmountAfterTax { get; private set; }
    public int ExtraPaxFrom { get; private set; }
    public int DiscountType { get; private set; }
    public int ExtraRateType { get; private set; }
    public int AgeFrom { get; private set; }
    public int AgeTo { get; private set; }

    private ExtraRate(
        int type,
        int paxOrder,
        decimal amountBeforeTax,
        decimal amountAfterTax,
        int extraPaxFrom,
        int discountType,
        int extraRateType,
        int ageFrom,
        int ageTo)
    {
        Type = type;
        PaxOrder = paxOrder;
        AmountBeforeTax = amountBeforeTax;
        AmountAfterTax = amountAfterTax;
        ExtraPaxFrom = extraPaxFrom;
        DiscountType = discountType;
        ExtraRateType = extraRateType;
        AgeFrom = ageFrom;
        AgeTo = ageTo;
    }

    public static Result<ExtraRate> Create(
        dynamic type,
        dynamic paxOrder,
        dynamic amountBeforeTax,
        dynamic amountAfterTax,
        dynamic extraPaxFrom,
        dynamic discountType,
        dynamic extraRateType,
        dynamic ageFrom,
        dynamic ageTo)
    {
        if (paxOrder == null)
        {
            return Result.Failure<ExtraRate>(ExtraRateErrors.NullOrEmpty(nameof(PaxOrder)));
        }

        if (type == null)
        {
            return Result.Failure<ExtraRate>(ExtraRateErrors.NullOrEmpty(nameof(Type)));
        }

        var result = new ExtraRate(
            (int)type,
            (int)paxOrder,
            (decimal)amountBeforeTax,
            (decimal)amountAfterTax,
            (int)extraPaxFrom,
            (int)discountType,
            (int)extraRateType,
            (int)ageFrom,
            (int)ageTo);

        return result;
    }
}
