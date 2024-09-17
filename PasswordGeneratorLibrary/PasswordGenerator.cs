namespace PasswordGeneratorLibrary
{
    /**
     * Authors: Martin Rohwedder
     * 
     * Password Generator class is responsible for generating random passwords, which upholds the strong password criterias.
     * 
     * Strong Password Criterias
     * 1. Password should be 10 characters or longer
     * 2. Password should contain both uppercase and lowercase letters, where there is at least 1 uppercase letter
     * 3. Password should contain at least 1 special character
     * 4. Password must not contain string literals equal to literals from the bad words collection (like 'qwwerty', 'test', '123456' etc.)
     */
    public class PasswordGenerator : IPasswordGenerator
    {
        private readonly char[] _letters = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'x', 'y', 'z'];
        private readonly char[] _specialCharacters = ['@', '!', '#', '$', '%', '/', '&', '(', ')', '=', '?', '[', ']', '{', '}', '-', '_', '*', '^', '+', '<', '>'];
        private readonly string[] _badWords = ["qwerty", "test", "123456", "hello", "world", "password", "admin"];

        /**
         * Generate a random password of 16 characters, which upholds the strong password criterias
         */
        public string GeneratePassword()
        {
            string generatedPassword = string.Empty;

            do
            {
                var characters = new string[16];

                for (int i = 0; i < characters.Length; i++)
                {
                    // grab 2 special characters to use
                    if (i < 2)
                    {
                        // Get a random special character
                        characters[i] = _specialCharacters[Random.Shared.Next(_specialCharacters.Length)].ToString();
                    }
                    // Grab 4 numerals to use
                    else if (i >= 2 && i <= 6)
                    {
                        // Get a random number between 0 and 9 and cast it as a char
                        characters[i] = Random.Shared.Next(10).ToString();
                    }
                    // Grab the remaining places as letters
                    else
                    {
                        //populate with random letters and make 50% chance of them to be upper case letters
                        characters[i] = (Random.Shared.Next(2) == 0) ? _letters[Random.Shared.Next(_letters.Length)].ToString() : _letters[Random.Shared.Next(_letters.Length)].ToString().ToUpper();
                    }
                }

                // Shuffle the characters array and then create is as the generated password
                Random.Shared.Shuffle(characters);
                generatedPassword = string.Concat(characters);
            }
            while (!IsPasswordStrong(generatedPassword));

            return generatedPassword;
        }

        /**
         * Check if the password provided upholds the strong password criterias
         */
        public bool IsPasswordStrong(string password)
        {
            bool isPasswordStrong = false;

            // Check if password is at least 10 charactes long, has upper and lower case characters, has numbers and special characters and doesnt contain any bad words.
            if (password.Length >= 10 && 
                password.Any(c => char.IsUpper(c)) && 
                password.Any(c => char.IsLower(c)) && 
                password.Any(c => char.IsNumber(c)) &&
                password.Any(c => !char.IsLetterOrDigit(c)) &&
                !_badWords.Any(s => password.Contains(s)))
            {
                isPasswordStrong = true;
            }

            return isPasswordStrong;
        }
    }
}
