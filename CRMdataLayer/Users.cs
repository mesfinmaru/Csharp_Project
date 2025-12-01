using CRMdataLayer;

public class UsersService
{
    public bool Validate(string username, string password)
    {
        using var db = new AppDBContext();

        return db.Users.Any(u => u.Username == username && u.Password == password);
    }
}
