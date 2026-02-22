using System.Text.Json;
using System.Text.Json.Serialization;

namespace Helmz.Core.Protocol.Serialization;

/// <summary>
/// JSON-based implementation of <see cref="IProtocolSerializer"/> using System.Text.Json.
/// </summary>
public sealed class JsonProtocolSerializer : IProtocolSerializer
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    /// <inheritdoc />
    public byte[] Serialize(HelmzMessage message)
    {
        return JsonSerializer.SerializeToUtf8Bytes(message, Options);
    }

    /// <inheritdoc />
    public HelmzMessage Deserialize(byte[] data)
    {
        return JsonSerializer.Deserialize<HelmzMessage>(data, Options)
            ?? throw new JsonException("Failed to deserialize HelmzMessage.");
    }

    /// <inheritdoc />
    public T DeserializePayload<T>(HelmzMessage message)
    {
        ArgumentNullException.ThrowIfNull(message);

        return message.Payload is JsonElement element
            ? element.Deserialize<T>(Options)
                ?? throw new JsonException($"Failed to deserialize payload as {typeof(T).Name}.")
            : throw new InvalidOperationException("Payload is not a JsonElement.");
    }
}
