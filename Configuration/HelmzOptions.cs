namespace Helmz.Core.Configuration;

/// <summary>
/// Configuration options for the Helmz application.
/// </summary>
public class HelmzOptions
{
    /// <summary>
    /// The configuration section name used in appsettings.
    /// </summary>
    public const string SectionName = "Helmz";

    /// <summary>
    /// Gets or sets the WebSocket URL of the relay server.
    /// </summary>
    public Uri RelayUrl { get; set; } = new("ws://localhost:5050/ws");

    /// <summary>
    /// Gets or sets the interval in seconds between heartbeat messages.
    /// </summary>
    public int HeartbeatIntervalSeconds { get; set; } = 30;

    /// <summary>
    /// Gets or sets the number of minutes before a room expires.
    /// </summary>
    public int RoomExpiryMinutes { get; set; } = 10;
}
