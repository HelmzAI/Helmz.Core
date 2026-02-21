using System.Text.Json.Serialization;

namespace Helmz.Core.Protocol;

public sealed record DaemonInfo(
    [property: JsonPropertyName("hostname")] string Hostname,
    [property: JsonPropertyName("os")] string Os,
    [property: JsonPropertyName("claudeVersion")] string? ClaudeVersion = null);

public sealed record SessionStatusPayload(
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("daemonInfo")] DaemonInfo? DaemonInfo = null);
