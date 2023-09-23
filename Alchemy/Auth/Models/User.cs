namespace Alchemy.Auth.Models;

public class User : AbstractUser
{
    public User(string username, string password) : base(username, password)
    {
    }

    public User(string username, string password, string email) : base(username, password, email)
    {
    }

    public User(string username, string password, string email, bool isAdmin) : base(username, password, email, isAdmin)
    {
    }
}
