namespace SyncDeal.Domain.Cryptography
{
    public interface IPasswordEncrypter
    {
        string Encrypt(string password);
        string Verify(string password, string passwordHash);
    }
}
