using System.Security.Cryptography;
using NSec.Cryptography;

namespace Helmz.Core.Crypto;

public sealed class X25519KeyExchange : IKeyExchange
{
    private static readonly KeyAgreementAlgorithm Algorithm = KeyAgreementAlgorithm.X25519;

    public KeyPairResult GenerateKeyPair()
    {
        using var key = Key.Create(
            Algorithm,
            new KeyCreationParameters { ExportPolicy = KeyExportPolicies.AllowPlaintextExport });

        var privateKeyBytes = key.Export(KeyBlobFormat.RawPrivateKey);
        var publicKeyBytes = key.PublicKey.Export(KeyBlobFormat.RawPublicKey);

        return new KeyPairResult(privateKeyBytes, publicKeyBytes);
    }

    public byte[] DeriveSharedKey(byte[] ourPrivateKey, byte[] theirPublicKey)
    {
        using var ourKey = Key.Import(Algorithm, ourPrivateKey, KeyBlobFormat.RawPrivateKey);
        var theirKey = NSec.Cryptography.PublicKey.Import(Algorithm, theirPublicKey, KeyBlobFormat.RawPublicKey);

        using var sharedSecret = Algorithm.Agree(ourKey, theirKey)
            ?? throw new CryptographicException("X25519 key agreement failed.");

        var rawSecret = sharedSecret.Export(SharedSecretBlobFormat.RawSharedSecret);

        return HKDF.DeriveKey(
            HashAlgorithmName.SHA256,
            rawSecret,
            outputLength: 32,
            info: "helm-e2e-v1"u8.ToArray());
    }
}
