using System.Text.Json.Serialization;

namespace Helmz.Core.Protocol;

public sealed record ErrorPayload(
    [property: JsonPropertyName("code")] string Code,
    [property: JsonPropertyName("message")] string Message);
