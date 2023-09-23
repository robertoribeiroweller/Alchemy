using Alchemy.Auth.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Alchemy.Tests.Auth;

[TestClass]
public class AbstractUserTests
{
    private const string Username = "TestUser";
    private const string Password = "StrongPassword";
    private const string Email = "testuser@example.com";

    [TestMethod]
    public void SetPassword_VerifyPassword_Success()
    {
        User user = new User(Username, Password);
        user.SetPassword(Password);

        bool passwordIsValid = user.VerifyPassword(Password);
        Assert.IsTrue(passwordIsValid);
    }

    [TestMethod]
    public void Constructor_WithUsernameAndPassword_InitializesProperties()
    {
        User user = new User(Username, Password);

        Assert.AreEqual(user.Username, Username);
        Assert.IsFalse(string.IsNullOrEmpty(user.Salt));
        Assert.IsFalse(string.IsNullOrEmpty(user.PasswordHash));
        Assert.IsFalse(user.IsAdmin);
        Assert.AreNotEqual(default(DateTime), user.DateJoined);
    }

    [TestMethod]
    public void Constructor_WithUsernamePasswordAndEmail_InitializesProperties()
    {
        User user = new User(Username, Password, Email);

        Assert.AreEqual(Username, "TestUser");
        Assert.IsFalse(string.IsNullOrEmpty(user.Salt));
        Assert.IsFalse(string.IsNullOrEmpty(user.PasswordHash));
        Assert.IsFalse(user.IsAdmin);
        Assert.AreEqual(Email, user.Email);
        Assert.AreNotEqual(default(DateTime), user.DateJoined);
    }

    [TestMethod]
    public void Constructor_WithAllParameters_InitializesProperties()
    {
        User user = new User(Username, Password, Email, true);

        Assert.AreEqual(Username, "TestUser");
        Assert.IsFalse(string.IsNullOrEmpty(user.Salt));
        Assert.IsFalse(string.IsNullOrEmpty(user.PasswordHash));
        Assert.IsTrue(user.IsAdmin);
        Assert.AreEqual(Email, user.Email);
        Assert.AreNotEqual(default(DateTime), user.DateJoined);
    }
}