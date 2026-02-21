namespace Helmz.Core.Configuration;

public class HelmzOptions
{
    public const string SectionName = "Helmz";

    public Uri RelayUrl { get; set; } = new("ws://localhost:5050/ws");
    public int HeartbeatIntervalSeconds { get; set; } = 30;
    public int RoomExpiryMinutes { get; set; } = 10;
}
