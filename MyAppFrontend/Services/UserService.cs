using System.Net.Http.Json;
using MyAppFrontend.Models;

namespace MyAppFrontend.Services;
public class UserService
{
    private readonly HttpClient _http;
    public UserService(HttpClient http)
    {
        _http = http;
    }
    public async Task<UserDto?> LoginAsync(string username, string password)
    {
        var response = await _http.PostAsJsonAsync("api/users/login", new { Username = username, Password = password });
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<UserDto>();
        }
        return null;
    }
}