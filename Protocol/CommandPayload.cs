using System.Text.Json.Serialization;

namespace Helmz.Core.Protocol;

public sealed record CommandPayload(
    [property: JsonPropertyName("prompt")] string Prompt,
    [property: JsonPropertyName("workingDirectory")] string? WorkingDirectory = null,
    [property: JsonPropertyName("sessionId")] string? SessionId = null,
    [property: JsonPropertyName("continueSession")] bool ContinueSession = false);
