using System.Text.Json.Serialization;

namespace Helmz.Core.Protocol;

/// <summary>
/// Payload containing a public key for the key exchange handshake.
/// </summary>
/// <param name="PublicKeyBase64">The Base64-encoded public key.</param>
public sealed record KeyExchangePayload(
    [property: JsonPropertyName("publicKey")] string PublicKeyBase64);
