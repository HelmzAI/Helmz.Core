using System.Text.Json.Serialization;

namespace Helmz.Core.Protocol;

public sealed record ActionResponsePayload(
    [property: JsonPropertyName("requestId")] string RequestId,
    [property: JsonPropertyName("approved")] bool Approved);
