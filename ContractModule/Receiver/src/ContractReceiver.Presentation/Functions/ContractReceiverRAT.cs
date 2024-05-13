using Microsoft.Extensions.Logging;

namespace ContractReceiver.Presentation.Functions
{
    public class ContractReceiverRAT
    {
        private readonly ILogger<ContractReceiverRAT> _logger;

        public ContractReceiverRAT(ILogger<ContractReceiverRAT> logger)
        {
            _logger = logger;
        }
    }
}
