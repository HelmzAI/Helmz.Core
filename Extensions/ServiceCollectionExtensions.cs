using Helmz.Core.Configuration;
using Helmz.Core.Crypto;
using Helmz.Core.Protocol.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Helmz.Core.Extensions;

/// <summary>
/// Extension methods for registering Helmz.Core services in the dependency injection container.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers all Helmz.Core services including crypto, serialization, and configuration.
    /// </summary>
    /// <param name="services">The service collection to add services to.</param>
    /// <param name="configuration">The configuration instance to bind options from.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddHelmzCore(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);

        _ = services.Configure<HelmzOptions>(configuration.GetSection(HelmzOptions.SectionName));
        _ = services.AddSingleton<IKeyExchange, X25519KeyExchange>();
        _ = services.AddSingleton<IMessageEncryptor, AesGcmMessageEncryptor>();
        _ = services.AddSingleton<IProtocolSerializer, JsonProtocolSerializer>();

        return services;
    }
}
