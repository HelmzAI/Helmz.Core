using System.Diagnostics.CodeAnalysis;

namespace Helmz.Core.Crypto;

[SuppressMessage("Performance", "CA1819:Properties should not return arrays")]
public sealed record KeyPairResult(byte[] PrivateKey, byte[] PublicKey);

public interface IKeyExchange
{
    KeyPairResult GenerateKeyPair();
    byte[] DeriveSharedKey(byte[] ourPrivateKey, byte[] theirPublicKey);
}
