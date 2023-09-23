using Alchemy.Auth.Utility;
namespace Alchemy.Tests.Auth;

[TestClass]
public class PasswordUtilityTests
{
    private const string Password = "StrongPassword";

    [TestMethod]
    public void HashPassword_ValidInput_ReturnsHashAndSalt()
    {
        (string hash, string salt) = PasswordUtility.HashPassword(Password);

        Assert.IsNotNull(hash);
        Assert.IsNotNull(salt);

        Assert.IsTrue(hash.Length > 0);
        Assert.IsTrue(salt.Length > 0);
    }

    [TestMethod]
    public void VerifyPassword_CorrectPassword_ReturnsTrue()
    {
        (string hash, string salt) = PasswordUtility.HashPassword(Password);

        bool result = PasswordUtility.VerifyPassword(Password, hash, salt);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void VerifyPassword_IncorrectPassword_ReturnFalse()
    {
        string incorrectPassword = "WrongPassword";
        (string hash, string salt) = PasswordUtility.HashPassword(Password);

        bool result = PasswordUtility.VerifyPassword(incorrectPassword, hash, salt);

        Assert.IsFalse(result);
    }
}