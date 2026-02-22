using System.Text.Json.Serialization;

namespace Helmz.Core.Protocol;

/// <summary>
/// Information about the daemon host environment.
/// </summary>
/// <param name="Hostname">The hostname of the machine running the daemon.</param>
/// <param name="Os">The operating system of the daemon host.</param>
/// <param name="ClaudeVersion">The optional version of Claude CLI installed on the daemon.</param>
public sealed record DaemonInfo(
    [property: JsonPropertyName("hostname")] string Hostname,
    [property: JsonPropertyName("os")] string Os,
    [property: JsonPropertyName("claudeVersion")] string? ClaudeVersion = null);

/// <summary>
/// Payload containing session status updates from the daemon.
/// </summary>
/// <param name="Status">The current status of the session (e.g., "connected", "busy").</param>
/// <param name="DaemonInfo">Optional information about the daemon host environment.</param>
public sealed record SessionStatusPayload(
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("daemonInfo")] DaemonInfo? DaemonInfo = null);
