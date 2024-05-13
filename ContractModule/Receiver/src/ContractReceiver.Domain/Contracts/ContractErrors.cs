using ContractReceiver.Domain.Shared.Entities;

namespace ContractReceiver.Domain.Contracts;

public static class ContractErrors
{
    public static Error RequiredAttribute(string attribute) => new(
        "Contract.RequiredAttribute",
        $"Required Attribute: {attribute}");

    public static Error UnableToParseAttribute(string attribute) => new(
        "Contract.UnableToParseAttribute",
        $"Unable to parse {attribute} attribute");

    public static Error InvalidType(ContractType contractType) => new(
        "Contract.InvalidType",
        $"Invalid Contract type value: {contractType}");

    public static Error InvalidBlobPath(string blobPath) => new(
        "Contract.InvalidBlobPath",
        $"Incorrect Path (Null): {blobPath}");

    public static Error NullOrEmpty(string blobPath) => new(
        "Contract.InvalidContract",
        $"Json is null or empty: {blobPath}");

    public static Error InvalidConstruction(string blobPath) => new(
        "Contract.InvalidConstruction",
        $"Can't create a contract. Blob: {blobPath}");

    public static Error Undeserializable(string blobPath) => new(
        "Contract.Undeserializable",
        $"Can't deserialize a json contract. Blob: {blobPath}");

    public static Error NotSent(string blobPath) => new(
        "Contract.NotSent",
        $"Can't send contract correctly. Blob: {blobPath}");

    public static Error InvalidReservationContainer(string? reservationContainer)
        => new(
        "Contract.NotSent",
        $"Can't read contract correctly because can't read configuration. Configuration: {reservationContainer}");
    
}