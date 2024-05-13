//using ContractReceiver.Domain.Contracts;
//using ContractReceiver.Domain.Shared;
//using Grpc.Net.Client;
//using Microsoft.Extensions.Configuration;

//namespace ContractReceiver.Infrastructure.Repositories
//{
//    public class ContractRepository : IContractRepository
//    {
//        private readonly IConfiguration _configuration;

//        private const string GRPC_MAPPER_URL = "grpc_mapper_url";

//        public ContractRepository(IConfiguration configuration)
//        {
//            _configuration = configuration;
//        }

//        public async Task<bool> SendContractAllotment(Contract contract)
//        {
//            ContractAllotmentClient client = new(GrpcChannel.ForAddress(_configuration.GetValue<string>(GRPC_MAPPER_URL)!));
//            ContractAllotmentRequest request = new() { Request = Methods.ContractToByteString(contract) };
//            var result = await client.SendContractAllotmentAsync(request);
//            return result.Response;
//        }

//        public async Task<bool> SendContractOpenClose(Contract contract)
//        {
//            ContractOpenCloseRequest request = new()
//            {
//                Request = Methods.ContractToByteString(contract)
//            };

//            ContractOpenCloseClient client = new(GrpcChannel.ForAddress(_configuration.GetValue<string>(GRPC_MAPPER_URL)!));

//            var result = await client.SendContractOpenCloseAsync(request);

//            return result.Response;
//        }

//        public async Task<bool> SendContractRate(Contract contract)
//        {
//            ContractRateClient client = new(GrpcChannel.ForAddress(_configuration.GetValue<string>(GRPC_MAPPER_URL)!));
//            ContractRateRequest request = new() { Request = Methods.ContractToByteString(contract) };
//            var result = await client.SendContractRateAsync(request);
//            return result.Response;
//        }

//        public async Task<bool> SendContractRateRestriction(Contract contract)
//        {
//            ContractRateRestrictionClient client = new(GrpcChannel.ForAddress(_configuration.GetValue<string>(GRPC_MAPPER_URL)!));
//            ContractRateRestrictionRequest request = new() { Request = Methods.ContractToByteString(contract) };
//            var result = await client.SendContractRateRestrictionAsync(request);
//            return result.Response;
//        }

//        public async Task<bool> SendContractRestriction(Contract contract)
//        {
//            ContractRestrictionClient client = new(GrpcChannel.ForAddress(_configuration.GetValue<string>(GRPC_MAPPER_URL)!));
//            ContractRestrictionRequest request = new() { Request = Methods.ContractToByteString(contract) };
//            var result = await client.SendContractRestrictionAsync(request);
//            return result.Response;
//        }
//    }
//}
