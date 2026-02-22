using System.Text.Json.Serialization;

namespace Helmz.Core.Protocol;

/// <summary>
/// Payload containing a command prompt sent from the mobile client to the daemon.
/// </summary>
/// <param name="Prompt">The command prompt text to execute.</param>
/// <param name="WorkingDirectory">The optional working directory for command execution.</param>
/// <param name="SessionId">The optional session identifier for session continuity.</param>
/// <param name="ContinueSession">Whether to continue an existing session instead of starting a new one.</param>
public sealed record CommandPayload(
    [property: JsonPropertyName("prompt")] string Prompt,
    [property: JsonPropertyName("workingDirectory")] string? WorkingDirectory = null,
    [property: JsonPropertyName("sessionId")] string? SessionId = null,
    [property: JsonPropertyName("continueSession")] bool ContinueSession = false);
