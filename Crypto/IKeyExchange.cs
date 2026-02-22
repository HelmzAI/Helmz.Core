using System.Diagnostics.CodeAnalysis;

namespace Helmz.Core.Crypto;

/// <summary>
/// Represents a generated key pair containing private and public keys.
/// </summary>
/// <param name="PrivateKey">The private key bytes.</param>
/// <param name="PublicKey">The public key bytes.</param>
[SuppressMessage("Performance", "CA1819:Properties should not return arrays")]
public sealed record KeyPairResult(byte[] PrivateKey, byte[] PublicKey);

/// <summary>
/// Defines operations for asymmetric key exchange.
/// </summary>
public interface IKeyExchange
{
    /// <summary>
    /// Generates a new asymmetric key pair.
    /// </summary>
    /// <returns>A <see cref="KeyPairResult"/> containing the private and public keys.</returns>
    KeyPairResult GenerateKeyPair();

    /// <summary>
    /// Derives a shared symmetric key from our private key and the peer's public key.
    /// </summary>
    /// <param name="ourPrivateKey">Our private key bytes.</param>
    /// <param name="theirPublicKey">The peer's public key bytes.</param>
    /// <returns>The derived shared key bytes.</returns>
    byte[] DeriveSharedKey(byte[] ourPrivateKey, byte[] theirPublicKey);
}
