using System.Text.Json.Serialization;

namespace Helmz.Core.Protocol;

public sealed record KeyExchangePayload(
    [property: JsonPropertyName("publicKey")] string PublicKeyBase64);
