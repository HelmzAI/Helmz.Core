using System.Security.Cryptography;

namespace Helmz.Core.Crypto;

/// <summary>
/// AES-256-GCM encryption with wire format: [nonce 12B] [ciphertext NB] [tag 16B]
/// </summary>
public sealed class AesGcmMessageEncryptor : IMessageEncryptor
{
    private const int NonceSize = 12;
    private const int TagSize = 16;

    public byte[] Encrypt(byte[] plaintext, byte[] key)
    {
        ArgumentNullException.ThrowIfNull(plaintext);
        ArgumentNullException.ThrowIfNull(key);

        var nonce = new byte[NonceSize];
        RandomNumberGenerator.Fill(nonce);

        var ciphertext = new byte[plaintext.Length];
        var tag = new byte[TagSize];

        using var aes = new AesGcm(key, TagSize);
        aes.Encrypt(nonce, plaintext, ciphertext, tag);

        // Wire format: [nonce (12)] [ciphertext (N)] [tag (16)]
        var result = new byte[NonceSize + ciphertext.Length + TagSize];
        nonce.CopyTo(result, 0);
        ciphertext.CopyTo(result, NonceSize);
        tag.CopyTo(result, NonceSize + ciphertext.Length);

        return result;
    }

    public byte[] Decrypt(byte[] encryptedBlob, byte[] key)
    {
        ArgumentNullException.ThrowIfNull(encryptedBlob);
        ArgumentNullException.ThrowIfNull(key);

        if (encryptedBlob.Length < NonceSize + TagSize)
            throw new CryptographicException("Encrypted blob is too short.");

        var nonce = encryptedBlob.AsSpan(0, NonceSize);
        var ciphertextLength = encryptedBlob.Length - NonceSize - TagSize;
        var ciphertext = encryptedBlob.AsSpan(NonceSize, ciphertextLength);
        var tag = encryptedBlob.AsSpan(NonceSize + ciphertextLength, TagSize);

        var plaintext = new byte[ciphertextLength];

        using var aes = new AesGcm(key, TagSize);
        aes.Decrypt(nonce, ciphertext, tag, plaintext);

        return plaintext;
    }
}
