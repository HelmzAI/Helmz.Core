using System.Text.Json;
using System.Text.Json.Serialization;

namespace Helmz.Core.Protocol.Serialization;

public sealed class JsonProtocolSerializer : IProtocolSerializer
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    public byte[] Serialize(HelmzMessage message)
    {
        return JsonSerializer.SerializeToUtf8Bytes(message, Options);
    }

    public HelmzMessage Deserialize(byte[] data)
    {
        return JsonSerializer.Deserialize<HelmzMessage>(data, Options)
            ?? throw new JsonException("Failed to deserialize HelmzMessage.");
    }

    public T DeserializePayload<T>(HelmzMessage message)
    {
        if (message.Payload is JsonElement element)
            return element.Deserialize<T>(Options)
                ?? throw new JsonException($"Failed to deserialize payload as {typeof(T).Name}.");

        throw new InvalidOperationException("Payload is not a JsonElement.");
    }
}
