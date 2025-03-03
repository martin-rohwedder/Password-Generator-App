using PasswordGeneratorLibrary;

namespace PasswordGeneratorUnitTest
{
    [TestFixture]
    internal class PasswordGeneratorTests
    {
        private IPasswordGenerator _passwordGenerator;

        [SetUp]
        public void SetUp()
        {
            // Arrange
            _passwordGenerator = new PasswordGenerator();
        }

        [TearDown]
        public void TearDown()
        {
            _passwordGenerator = null;
        }

        /**
         * Method: GenerateCustomPassword(int passwordLength, int numberOfUppercaseLetters, int numberOfSpecialCharacters, int numberOfNumerals)
         * 
         * Test if the method returns a randomly generated string which is 10 characters long, and still upholding the strong 
         * password criterias which is:
         * - both upper and lowercase letters used
         * - minimum one special character used
         * - password length is minimum 10 characters or longer.
         * - has at least 1 numeral
         * - has no "bad" words
         **/
        [Test]
        [TestCase(10, 1, 1, 1)]
        [TestCase(10, 2, 2, 2)]
        [TestCase(10, 3, 3, 3)]
        [TestCase(10, 1, 2, 3)]
        public void GenerateCustomPassword_Should_Return_RandomStringWhichIsTenCharactersLongAndUpholdsTheStrongPasswordCriteria(int passwordLength, int numberOfUppercaseLetters, int numberOfSpecialCharacters, int numberOfNumerals)
        {
            // Act
            var firstGeneratedPassword = _passwordGenerator.GenerateCustomPassword(passwordLength, numberOfUppercaseLetters, numberOfSpecialCharacters, numberOfNumerals);
            var secondGeneratedPassword = _passwordGenerator.GenerateCustomPassword(passwordLength, numberOfUppercaseLetters, numberOfSpecialCharacters, numberOfNumerals);

            // Assert
            Assert.Multiple(() =>
            {
                // Password should be a new random string literal every time
                Assert.That(firstGeneratedPassword, Is.Not.EqualTo(secondGeneratedPassword));
                // Password should contain at least one uppercase character
                Assert.That(firstGeneratedPassword.Any(c => char.IsUpper(c)), Is.True);
                // Password should contain at least one lowercase character
                Assert.That(firstGeneratedPassword.Any(c => char.IsLower(c)), Is.True);
                // Password should contain at least one special character
                Assert.That(firstGeneratedPassword.Any(c => !char.IsLetterOrDigit(c)), Is.True);
                // Password should contain at least one numeral
                Assert.That(firstGeneratedPassword.Any(c => char.IsNumber(c)), Is.True);
                // Password should be 16 characters long
                Assert.That(firstGeneratedPassword.Length, Is.EqualTo(10));
            });
        }

        /**
         * Method: GenerateCustomPassword(int passwordLength, int numberOfUppercaseLetters, int numberOfSpecialCharacters, int numberOfNumerals)
         * 
         * Test if the method returns a randomly generated string which is 10 characters long, and still upholding the strong 
         * password criterias which is:
         * - both upper and lowercase letters used
         * - minimum one special character used
         * - password length is minimum 10 characters or longer.
         * - has at least 1 numeral
         * - has no "bad" words
         **/
        [Test]
        [TestCase(20, 1, 1, 1)]
        [TestCase(20, 2, 2, 2)]
        [TestCase(20, 3, 3, 3)]
        [TestCase(20, 1, 2, 3)]
        public void GenerateCustomPassword_Should_Return_RandomStringWhichIsTwentyCharactersLongAndUpholdsTheStrongPasswordCriteria(int passwordLength, int numberOfUppercaseLetters, int numberOfSpecialCharacters, int numberOfNumerals)
        {
            // Act
            var firstGeneratedPassword = _passwordGenerator.GenerateCustomPassword(passwordLength, numberOfUppercaseLetters, numberOfSpecialCharacters, numberOfNumerals);
            var secondGeneratedPassword = _passwordGenerator.GenerateCustomPassword(passwordLength, numberOfUppercaseLetters, numberOfSpecialCharacters, numberOfNumerals);

            // Assert
            Assert.Multiple(() =>
            {
                // Password should be a new random string literal every time
                Assert.That(firstGeneratedPassword, Is.Not.EqualTo(secondGeneratedPassword));
                // Password should contain at least one uppercase character
                Assert.That(firstGeneratedPassword.Any(c => char.IsUpper(c)), Is.True);
                // Password should contain at least one lowercase character
                Assert.That(firstGeneratedPassword.Any(c => char.IsLower(c)), Is.True);
                // Password should contain at least one special character
                Assert.That(firstGeneratedPassword.Any(c => !char.IsLetterOrDigit(c)), Is.True);
                // Password should contain at least one numeral
                Assert.That(firstGeneratedPassword.Any(c => char.IsNumber(c)), Is.True);
                // Password should be 16 characters long
                Assert.That(firstGeneratedPassword.Length, Is.EqualTo(20));
            });
        }

        /**
         * Method: GeneratePassword()
         * 
         * Test if the method returns a randomly generated string while still upholding the strong password criterias
         * Strong Password Criterias is:
         * - both upper and lowercase letters used
         * - minimum one special character used
         * - password length is minimum 10 characters or longer.
         * - has at least 1 numeral
         * - has no "bad" words
         **/
        [Test]
        public void GeneratePassword_Should_Return_RandomStringAndUpholdTheStrongPasswordCriterias()
        {
            // Act
            var firstGeneratedPassword = _passwordGenerator.GeneratePassword();
            var secondGeneratedPassword = _passwordGenerator.GeneratePassword();

            // Assert
            Assert.Multiple(() =>
            {
                // Password should be a new random string literal every time
                Assert.That(firstGeneratedPassword, Is.Not.EqualTo(secondGeneratedPassword));
                // Password should contain at least one uppercase character
                Assert.That(firstGeneratedPassword.Any(c => char.IsUpper(c)), Is.True);
                // Password should contain at least one lowercase character
                Assert.That(firstGeneratedPassword.Any(c => char.IsLower(c)), Is.True);
                // Password should contain at least one special character
                Assert.That(firstGeneratedPassword.Any(c => !char.IsLetterOrDigit(c)), Is.True);
                // Password should contain at least one numeral
                Assert.That(firstGeneratedPassword.Any(c => char.IsNumber(c)), Is.True);
                // Password should be 16 characters long
                Assert.That(firstGeneratedPassword.Length, Is.EqualTo(16));
            });
        }

        /**
         * Method: IsPasswordStrong(String password)
         * 
         * Test if the method IsPasswordStrong is returning true on the passwords provided which upholds the strong password 
         * criteria, which is:
         * - both upper and lowercase letters used
         * - minimum one special character used
         * - password length is minimum 10 characters or longer.
         * - has at least 1 numeral
         * - has no "bad" words
         **/
        [Test]
        [TestCase("4ug87#6hthR@paeq")]
        [TestCase("&jK876hthpaeq71M")]
        public void IsPasswordStrong_Should_Return_TrueWhenPasswordUpholdsTheStrongPasswordCriterias(string password)
        {
            // Act
            bool isPasswordStrong = _passwordGenerator.IsPasswordStrong(password);

            // Assert
            Assert.IsTrue(isPasswordStrong);
        }

        /**
         * Method: IsPasswordStrong(String password)
         * 
         * Test if the method IsPasswordStrong is returning false on the passwords provided which does not upholds the strong password 
         * criteria, which is:
         * - both upper and lowercase letters used
         * - minimum one special character used
         * - password length is minimum 10 characters or longer.
         * - has at least 1 numeral
         * - has no "bad" words
         **/
        [Test]
        [TestCase("test@58lksd94AI&")]
        [TestCase("@123456lksduhAIg")]
        [TestCase("lks412duhPsg86sd")]
        [TestCase("lksolkduhP$gfgsd")]
        [TestCase("lkytlk5uhwsgfgs#")]
        public void IsPasswordStrong_Should_Return_FalseWhenPasswordNotUpholdsTheStrongPasswordCriteria(string password)
        {
            // Act
            bool isPasswordStrong = _passwordGenerator.IsPasswordStrong(password);

            // Assert
            Assert.IsFalse(isPasswordStrong);
        }
    }
}
