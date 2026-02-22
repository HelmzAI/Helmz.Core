using System.Text.Json.Serialization;

namespace Helmz.Core.Protocol;

/// <summary>
/// Payload representing an error that occurred during processing.
/// </summary>
/// <param name="Code">The error code identifying the type of error.</param>
/// <param name="Message">A human-readable description of the error.</param>
public sealed record ErrorPayload(
    [property: JsonPropertyName("code")] string Code,
    [property: JsonPropertyName("message")] string Message);
