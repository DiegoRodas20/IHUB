using ContractReceiver.Domain.Contracts;
using ContractReceiver.Domain.Shared.Repository;
using ContractReceiver.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ContractReceiver.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUtilsRepository, UtilsRepository>();
        services.AddScoped<IContractRepository, ContractRepository>();
    }
}
