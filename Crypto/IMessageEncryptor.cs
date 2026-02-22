namespace Helmz.Core.Crypto;

/// <summary>
/// Defines operations for symmetric message encryption and decryption.
/// </summary>
public interface IMessageEncryptor
{
    /// <summary>
    /// Encrypts plaintext using the specified symmetric key.
    /// </summary>
    /// <param name="plaintext">The data to encrypt.</param>
    /// <param name="key">The symmetric encryption key.</param>
    /// <returns>The encrypted blob including any required metadata (nonce, tag).</returns>
    byte[] Encrypt(byte[] plaintext, byte[] key);

    /// <summary>
    /// Decrypts an encrypted blob using the specified symmetric key.
    /// </summary>
    /// <param name="encryptedBlob">The encrypted data to decrypt.</param>
    /// <param name="key">The symmetric encryption key.</param>
    /// <returns>The decrypted plaintext bytes.</returns>
    byte[] Decrypt(byte[] encryptedBlob, byte[] key);
}
