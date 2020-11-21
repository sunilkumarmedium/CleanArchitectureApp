namespace CleanArchitectureApp.Application.Interfaces.Services
{
    public interface IPasswordService
    {
        void CreatePasswordHash(string password, out string passwordHash, out string passwordSalt);

        bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt);

        string Base64Decode(string password);

        bool IsBase64String(string s);

        string GeneratePassword(int passwordlength);
    }
}