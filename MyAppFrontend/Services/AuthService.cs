namespace MyAppFrontend.Services;
public class AuthService
{
    public bool IsLoggedIn { get; private set; } = false;
    public string LoggedInUser { get; private set; } = "";
    public int LoggedInUserId { get; private set; } = 0;

    public void Login(string username, int userId)
    {
        IsLoggedIn = true;
        LoggedInUser = username;
        LoggedInUserId = userId;
    }

    public void Logout()
    {
        IsLoggedIn = false;
        LoggedInUser = "";
        LoggedInUserId = 0;
    }
}