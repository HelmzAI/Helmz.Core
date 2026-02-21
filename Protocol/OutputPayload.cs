using System.Text.Json.Serialization;

namespace Helmz.Core.Protocol;

public enum OutputStreamType { Stdout, Stderr, System }

public sealed record OutputPayload(
    [property: JsonPropertyName("content")] string Content,
    [property: JsonPropertyName("streamType")] OutputStreamType StreamType,
    [property: JsonPropertyName("isFinal")] bool IsFinal = false,
    [property: JsonPropertyName("sessionId")] string? SessionId = null);
