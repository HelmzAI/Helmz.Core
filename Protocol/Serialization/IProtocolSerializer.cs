namespace Helmz.Core.Protocol.Serialization;

public interface IProtocolSerializer
{
    byte[] Serialize(HelmzMessage message);
    HelmzMessage Deserialize(byte[] data);
    T DeserializePayload<T>(HelmzMessage message);
}
