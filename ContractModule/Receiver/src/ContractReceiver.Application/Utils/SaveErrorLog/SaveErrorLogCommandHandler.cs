using ContractReceiver.Application.Abstractions.Messaging;
using ContractReceiver.Domain.Shared.Repository;
using ContractReceiver.Domain.Shared.Entities;

namespace ContractReceiver.Application.Utils.SaveErrorLog;

internal sealed class SaveErrorLogCommandHandler(IUtilsRepository utilsRepository)
    : ICommandHandler<SaveErrorLogCommand>
{
    public async Task<Result> Handle(SaveErrorLogCommand request, CancellationToken cancellationToken)
    {
        if (request.Result.IsSuccess)
        {
            return SaveErrorLogErrors.ResultIsSuccess();
        }

        if (string.IsNullOrEmpty(request.Result.Error.Code))
        {
            return SaveErrorLogErrors.NullOrEmptyErrorCode();
        }

        if (string.IsNullOrEmpty(request.Result.Error.Description))
        {
            return SaveErrorLogErrors.NullOrEmptyDescription();
        }

        await utilsRepository.SaveErrorLog(request.Result);

        return Result.Success();
    }
}
