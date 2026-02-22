using System.Text.Json.Serialization;

namespace Helmz.Core.Protocol;

/// <summary>
/// Represents a protocol message exchanged between Helmz components.
/// </summary>
public sealed class HelmzMessage
{
    /// <summary>
    /// Gets the type of this message.
    /// </summary>
    [JsonPropertyName("type")]
    public MessageType Type { get; init; }

    /// <summary>
    /// Gets the unique identifier for this message.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; init; } = Guid.NewGuid().ToString("N");

    /// <summary>
    /// Gets the UTC timestamp when this message was created.
    /// </summary>
    [JsonPropertyName("timestamp")]
    public DateTimeOffset Timestamp { get; init; } = DateTimeOffset.UtcNow;

    /// <summary>
    /// Gets the message payload, whose type varies based on <see cref="Type"/>.
    /// </summary>
    [JsonPropertyName("payload")]
    public object? Payload { get; init; }
}
