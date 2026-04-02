using Microsoft.AspNetCore.Mvc;
using MyAppBackend.DTOs;
using MyAppBackend.Models;
using MyAppBackend.Services;

[ApiController]
[Route("api/[controller]")]
public class TaskItemController : ControllerBase
{
    private readonly TaskItemService _service;

    public TaskItemController(TaskItemService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tasks = await _service.GetAllAsync();

        var result = tasks.Select(t => new TaskItemDto
        {
            Id = t.Id,
            Title = t.Title,
            IsCompleted = t.IsCompleted,
            UserId = t.UserId
        });

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTaskItemDto dto)
    {
        var task = new TaskItem
        {
            Title = dto.Title,
            Description = dto.Description,
            DueDate = dto.DueDate,
            Difficulty = dto.Difficulty,
            UserId = dto.UserId,
            IsCompleted = false
        };

        var created = await _service.CreateAsync(task);

        return Ok(created);
    }
}