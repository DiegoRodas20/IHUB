using ContractReceiver.Domain.Shared.Entities;

namespace ContractReceiver.Domain.ExtraRates;

public class ExtraRatesBuilder
{
    public static Result<List<ExtraRate>> CreateExtraRate(dynamic extraRates)
    {
        List<ExtraRate> clientExtraRateResult = [];

        foreach (var extraRate in extraRates)
        {
            Result<ExtraRate> extraRateResult = ExtraRate.Create(
                extraRate.ExtraType,
                extraRate.PaxOrder,
                extraRate.AmountBeforeTax,
                extraRate.AmountAfterTax,
                extraRate.ExtraPaxFrom,
                extraRate.DiscountType,
                extraRate.ExtraRateType,
                extraRate.AgeFrom,
                extraRate.AgeTo);

            if (extraRateResult.IsFailure)
            {
                return Result.Failure<List<ExtraRate>>(extraRateResult.Error);
            }

            clientExtraRateResult.Add(extraRateResult.Value);
        }

        return clientExtraRateResult;
    }
}
