namespace Helmz.Core.Protocol.Serialization;

/// <summary>
/// Defines operations for serializing and deserializing Helmz protocol messages.
/// </summary>
public interface IProtocolSerializer
{
    /// <summary>
    /// Serializes a <see cref="HelmzMessage"/> to a byte array.
    /// </summary>
    /// <param name="message">The message to serialize.</param>
    /// <returns>The serialized byte array.</returns>
    byte[] Serialize(HelmzMessage message);

    /// <summary>
    /// Deserializes a byte array into a <see cref="HelmzMessage"/>.
    /// </summary>
    /// <param name="data">The byte array to deserialize.</param>
    /// <returns>The deserialized message.</returns>
    HelmzMessage Deserialize(byte[] data);

    /// <summary>
    /// Deserializes the payload of a <see cref="HelmzMessage"/> into a strongly-typed object.
    /// </summary>
    /// <typeparam name="T">The target payload type.</typeparam>
    /// <param name="message">The message whose payload to deserialize.</param>
    /// <returns>The deserialized payload.</returns>
    T DeserializePayload<T>(HelmzMessage message);
}
