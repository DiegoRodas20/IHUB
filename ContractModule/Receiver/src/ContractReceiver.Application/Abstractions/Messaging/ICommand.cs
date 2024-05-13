using ContractReceiver.Domain.Shared.Entities;
using MediatR;

namespace ContractReceiver.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}