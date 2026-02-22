using System.Text.Json.Serialization;

namespace Helmz.Core.Protocol;

/// <summary>
/// Payload sent when the daemon requests approval for a tool action.
/// </summary>
/// <param name="ToolName">The name of the tool requesting execution.</param>
/// <param name="ToolInput">The input arguments for the tool.</param>
/// <param name="Description">A human-readable description of the action.</param>
/// <param name="RequestId">The unique identifier for this approval request.</param>
public sealed record ActionRequestPayload(
    [property: JsonPropertyName("toolName")] string ToolName,
    [property: JsonPropertyName("toolInput")] string ToolInput,
    [property: JsonPropertyName("description")] string Description,
    [property: JsonPropertyName("requestId")] string RequestId);
