using System.Text.Json.Serialization;

namespace Helmz.Core.Protocol;

/// <summary>
/// Payload for heartbeat messages used to keep the connection alive.
/// </summary>
/// <param name="Role">The role of the sender (e.g., "daemon" or "mobile").</param>
public sealed record HeartbeatPayload(
    [property: JsonPropertyName("role")] string Role);
