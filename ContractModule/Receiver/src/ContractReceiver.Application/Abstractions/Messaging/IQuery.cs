using ContractReceiver.Domain.Shared.Entities;
using MediatR;

namespace ContractReceiver.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
