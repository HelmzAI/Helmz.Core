using System.Security.Cryptography;

namespace Helmz.Core.Crypto;

/// <summary>
/// AES-256-GCM encryption with wire format: [nonce 12B] [ciphertext NB] [tag 16B].
/// </summary>
public sealed class AesGcmMessageEncryptor : IMessageEncryptor
{
    private const int NonceSize = 12;
    private const int TagSize = 16;

    /// <inheritdoc />
    public byte[] Encrypt(byte[] plaintext, byte[] key)
    {
        ArgumentNullException.ThrowIfNull(plaintext);
        ArgumentNullException.ThrowIfNull(key);

        byte[] nonce = new byte[NonceSize];
        RandomNumberGenerator.Fill(nonce);

        byte[] ciphertext = new byte[plaintext.Length];
        byte[] tag = new byte[TagSize];

        using AesGcm aes = new(key, TagSize);
        aes.Encrypt(nonce, plaintext, ciphertext, tag);

        // Wire format: [nonce (12)] [ciphertext (N)] [tag (16)]
        byte[] result = new byte[NonceSize + ciphertext.Length + TagSize];
        nonce.CopyTo(result, 0);
        ciphertext.CopyTo(result, NonceSize);
        tag.CopyTo(result, NonceSize + ciphertext.Length);

        return result;
    }

    /// <inheritdoc />
    public byte[] Decrypt(byte[] encryptedBlob, byte[] key)
    {
        ArgumentNullException.ThrowIfNull(encryptedBlob);
        ArgumentNullException.ThrowIfNull(key);

        if (encryptedBlob.Length < NonceSize + TagSize)
        {
            throw new CryptographicException("Encrypted blob is too short.");
        }

        ReadOnlySpan<byte> nonce = encryptedBlob.AsSpan(0, NonceSize);
        int ciphertextLength = encryptedBlob.Length - NonceSize - TagSize;
        ReadOnlySpan<byte> ciphertext = encryptedBlob.AsSpan(NonceSize, ciphertextLength);
        ReadOnlySpan<byte> tag = encryptedBlob.AsSpan(NonceSize + ciphertextLength, TagSize);

        byte[] plaintext = new byte[ciphertextLength];

        using AesGcm aes = new(key, TagSize);
        aes.Decrypt(nonce, ciphertext, tag, plaintext);

        return plaintext;
    }
}
