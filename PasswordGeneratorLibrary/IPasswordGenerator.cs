namespace PasswordGeneratorLibrary
{
    public interface IPasswordGenerator
    {
        string GeneratePassword();
        bool IsPasswordStrong(string password);
    }
}
