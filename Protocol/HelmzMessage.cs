using System.Text.Json.Serialization;

namespace Helmz.Core.Protocol;

public sealed class HelmzMessage
{
    [JsonPropertyName("type")]
    public MessageType Type { get; init; }

    [JsonPropertyName("id")]
    public string Id { get; init; } = Guid.NewGuid().ToString("N");

    [JsonPropertyName("timestamp")]
    public DateTimeOffset Timestamp { get; init; } = DateTimeOffset.UtcNow;

    [JsonPropertyName("payload")]
    public object? Payload { get; init; }
}
