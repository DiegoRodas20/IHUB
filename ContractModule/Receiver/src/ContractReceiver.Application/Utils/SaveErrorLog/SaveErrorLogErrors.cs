using ContractReceiver.Domain.Shared.Entities;

namespace ContractReceiver.Application.Utils.SaveErrorLog;

public class SaveErrorLogErrors
{
    public static Error ResultIsSuccess() => new(
        "SaveErrorsLog.ResultIsSuccess",
        "The result is success so it won't be saved as error.");

    public static Error NullOrEmptyErrorCode() => new(
        "SaveErrorsLog.NullOrEmptyErrorCode",
        "Result with null or empty error code");

    public static Error NullOrEmptyDescription() => new(
        "SaveErrorsLog.NullOrEmptyDescription",
        "Result with null or empty error description");

    public static Error UncontrolledException(string exceptionMessage) => new(
        "SaveErrorsLog.UncontrolledException",
        $"Uncontroled exception: {exceptionMessage}");
}