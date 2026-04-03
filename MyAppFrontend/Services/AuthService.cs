namespace MyAppFrontend.Services;

public class AuthService
{
    public bool IsLoggedIn { get; private set; } = false;
    public string LoggedInUser { get; private set; } = "";

    public void Login(string username)
    {
        IsLoggedIn = true;
        LoggedInUser = username;
    }

    public void Logout()
    {
        IsLoggedIn = false;
        LoggedInUser = "";
    }
}