#pragma warning disable CS8618
using Alchemy.Auth.Utility;
using Alchemy.Shared.Models;

namespace Alchemy.Auth.Models;

public abstract class AbstractUser : BaseEntity
{
    public string Username { get; set; }
    public string? Email { get; set; }
    public string PasswordHash { get; set; }
    public string Salt { get; set; }
    public bool IsAdmin { get; set; }
    public DateTime DateJoined { get; set; }

    public void SetPassword(string password)
    {
        (PasswordHash, Salt) = PasswordUtility.HashPassword(password);
    }

    public bool VerifyPassword(string password)
    {
        return PasswordUtility.VerifyPassword(password, PasswordHash, Salt);
    }

    public AbstractUser() {  }  // Empty constructor for Entity Framework.

    public AbstractUser(string username, string password)
    {
        Username = username;
        Salt = Guid.NewGuid().ToString();
        SetPassword(password);
        DateJoined = DateTime.UtcNow;
        IsAdmin = false;
    }

    public AbstractUser(string username, string password, string email)
    : this(username, password)
    {
        Email = email;
        Salt = Guid.NewGuid().ToString();
        SetPassword(password);
        DateJoined = DateTime.UtcNow;
        IsAdmin = false;
    }

    public AbstractUser(string username, string password, string email, bool isAdmin)
    : this(username, password, email)
    {
        DateJoined = DateTime.UtcNow;
        Salt = Guid.NewGuid().ToString();
        SetPassword(password);
        IsAdmin = isAdmin;
    }
}