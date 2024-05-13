using ContractReceiver.Application.Abstractions.Messaging;

namespace ContractReceiver.Application.Contracts.ContractProccess;

public sealed record ContractProccessCommand(

    string BlobPath,

    string? ReservationContainer

) : ICommand;