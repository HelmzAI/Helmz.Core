using Helmz.Core.Configuration;
using Helmz.Core.Crypto;
using Helmz.Core.Protocol.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Helmz.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHelmzCore(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);

        services.Configure<HelmzOptions>(configuration.GetSection(HelmzOptions.SectionName));
        services.AddSingleton<IKeyExchange, X25519KeyExchange>();
        services.AddSingleton<IMessageEncryptor, AesGcmMessageEncryptor>();
        services.AddSingleton<IProtocolSerializer, JsonProtocolSerializer>();

        return services;
    }
}
