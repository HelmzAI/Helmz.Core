using System.Text.Json.Serialization;

namespace Helmz.Core.Protocol;

public sealed record ActionRequestPayload(
    [property: JsonPropertyName("toolName")] string ToolName,
    [property: JsonPropertyName("toolInput")] string ToolInput,
    [property: JsonPropertyName("description")] string Description,
    [property: JsonPropertyName("requestId")] string RequestId);
