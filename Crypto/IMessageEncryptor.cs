namespace Helmz.Core.Crypto;

public interface IMessageEncryptor
{
    byte[] Encrypt(byte[] plaintext, byte[] key);
    byte[] Decrypt(byte[] encryptedBlob, byte[] key);
}
