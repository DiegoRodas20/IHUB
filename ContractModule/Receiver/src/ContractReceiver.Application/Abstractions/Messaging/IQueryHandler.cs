using ContractReceiver.Domain.Shared.Entities;
using MediatR;

namespace ContractReceiver.Application.Abstractions.Messaging;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}
