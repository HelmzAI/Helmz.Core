using System.Text.Json.Serialization;

namespace Helmz.Core.Protocol;

public sealed record HeartbeatPayload(
    [property: JsonPropertyName("role")] string Role);
