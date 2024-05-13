using ContractReceiver.Domain.Contracts;
using Google.Protobuf;

using System.Text;
using System.Text.Json;

namespace ContractReceiver.Domain.Shared;

public static class Methods
{
    public static ByteString ContractToByteString(Contract contract)
    {
        string contractJson = JsonSerializer.Serialize(contract);
        byte[] contractData = Encoding.UTF8.GetBytes(contractJson);
        return ByteString.CopyFrom(contractData);
    }

    public static string FilePathCreate(Guid contractId)
    {
        DateTime date = DateTime.UtcNow;
        return $"{date.Year}/{date.Month:D2}/{date.Day:D2}/{contractId}.json";
    }
}