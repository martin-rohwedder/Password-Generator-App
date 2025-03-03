namespace PasswordGeneratorLibrary
{
    public interface IPasswordGenerator
    {
        string GenerateCustomPassword(int passwordLength, int numberOfUppercaseLetters, int numberOfSpecialCharacters, int numberOfNumerals);
        string GeneratePassword();
        bool IsPasswordStrong(string password);
    }
}
