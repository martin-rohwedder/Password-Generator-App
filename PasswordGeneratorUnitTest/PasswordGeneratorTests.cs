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
         * Method: Generate Password
         * 
         * Test if the method returns a randomly generated string while still upholding the strong password criterias
         * Strong Password Criterias is:
         * - both upper and lowercase letters used
         * - minimum one special character used
         * - password length is 10 characters or longer.
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
                // Password should be 16 characters long
                Assert.That(firstGeneratedPassword.Length, Is.EqualTo(16));
            });
        }

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
