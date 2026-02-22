using System.Security.Cryptography;
using NSec.Cryptography;

namespace Helmz.Core.Crypto;

/// <summary>
/// X25519 Diffie-Hellman key exchange with HKDF-SHA256 key derivation.
/// </summary>
public sealed class X25519KeyExchange : IKeyExchange
{
    private static readonly KeyAgreementAlgorithm Algorithm = KeyAgreementAlgorithm.X25519;

    /// <inheritdoc />
    public KeyPairResult GenerateKeyPair()
    {
        using Key key = Key.Create(
            Algorithm,
            new KeyCreationParameters { ExportPolicy = KeyExportPolicies.AllowPlaintextExport });

        byte[] privateKeyBytes = key.Export(KeyBlobFormat.RawPrivateKey);
        byte[] publicKeyBytes = key.PublicKey.Export(KeyBlobFormat.RawPublicKey);

        return new KeyPairResult(privateKeyBytes, publicKeyBytes);
    }

    /// <inheritdoc />
    public byte[] DeriveSharedKey(byte[] ourPrivateKey, byte[] theirPublicKey)
    {
        using Key ourKey = Key.Import(Algorithm, ourPrivateKey, KeyBlobFormat.RawPrivateKey);
        NSec.Cryptography.PublicKey theirKey = NSec.Cryptography.PublicKey.Import(Algorithm, theirPublicKey, KeyBlobFormat.RawPublicKey);

        using SharedSecret sharedSecret = Algorithm.Agree(ourKey, theirKey)
            ?? throw new CryptographicException("X25519 key agreement failed.");

        byte[] rawSecret = sharedSecret.Export(SharedSecretBlobFormat.RawSharedSecret);

        return HKDF.DeriveKey(
            HashAlgorithmName.SHA256,
            rawSecret,
            outputLength: 32,
            info: "helm-e2e-v1"u8.ToArray());
    }
}
