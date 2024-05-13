using ContractReceiver.Application.Abstractions.Messaging;
using ContractReceiver.Domain.Shared.Entities;

namespace ContractReceiver.Application.Utils.SaveErrorLog;

public sealed record SaveErrorLogCommand(
    
    Result Result

) : ICommand;