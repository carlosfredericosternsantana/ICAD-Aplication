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
}