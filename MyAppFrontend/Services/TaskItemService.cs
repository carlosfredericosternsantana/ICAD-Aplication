using System.Net.Http.Json;
namespace MyAppFrontend.Services;
public class TaskItemService
{
    private readonly HttpClient _http;
    public TaskItemService(HttpClient http)
    {
        _http = http;
    }
    public async Task<List<TaskItemDto>> GetAllAsync()
    {
        return await _http.GetFromJsonAsync<List<TaskItemDto>>("api/taskitem");
    }
    public async Task<TaskItemDto?> GetByIdAsync(int id)
    {
        return await _http.GetFromJsonAsync<TaskItemDto>($"api/taskitem/{id}");
    }
    public async Task CreateAsync(TaskItemDto task)
    {
        await _http.PostAsJsonAsync("api/taskitem", task);
    }
    public async Task UpdateAsync(int id, TaskItemDto task)
    {
        await _http.PutAsJsonAsync($"api/taskitem/{id}", task);
    }
    public async Task DeleteAsync(int id)
    {
        await _http.DeleteAsync($"api/taskitem/{id}");
    }
    public async Task<List<TaskItemDto>> GetByUserAsync(int userId)
    {
        return await _http.GetFromJsonAsync<List<TaskItemDto>>($"api/taskitem/user/{userId}");
    }
}