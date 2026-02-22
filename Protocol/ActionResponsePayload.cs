using System.Text.Json.Serialization;

namespace Helmz.Core.Protocol;

/// <summary>
/// Payload sent in response to an action approval request.
/// </summary>
/// <param name="RequestId">The identifier of the original action request being responded to.</param>
/// <param name="Approved">Whether the requested action was approved.</param>
public sealed record ActionResponsePayload(
    [property: JsonPropertyName("requestId")] string RequestId,
    [property: JsonPropertyName("approved")] bool Approved);
