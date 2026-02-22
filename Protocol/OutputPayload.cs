using System.Text.Json.Serialization;

namespace Helmz.Core.Protocol;

/// <summary>
/// Defines the type of output stream.
/// </summary>
public enum OutputStreamType
{
    /// <summary>
    /// Standard output stream.
    /// </summary>
    Stdout,

    /// <summary>
    /// Standard error stream.
    /// </summary>
    Stderr,

    /// <summary>
    /// System-level informational messages.
    /// </summary>
    System
}

/// <summary>
/// Payload containing output content streamed from the daemon.
/// </summary>
/// <param name="Content">The output text content.</param>
/// <param name="StreamType">The type of output stream this content originated from.</param>
/// <param name="IsFinal">Whether this is the final output chunk for the current command.</param>
/// <param name="SessionId">The optional session identifier this output belongs to.</param>
public sealed record OutputPayload(
    [property: JsonPropertyName("content")] string Content,
    [property: JsonPropertyName("streamType")] OutputStreamType StreamType,
    [property: JsonPropertyName("isFinal")] bool IsFinal = false,
    [property: JsonPropertyName("sessionId")] string? SessionId = null);
