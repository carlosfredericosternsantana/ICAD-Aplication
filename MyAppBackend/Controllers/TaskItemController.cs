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
            Description = t.Description,
            DueDate = t.DueDate,
            Difficulty = t.Difficulty,
            IsCompleted = t.IsCompleted,
            UserId = t.UserId,
            UserName = t.User?.Username
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
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, TaskItem updated)
    {
        var task = await _service.UpdateAsync(id, updated);
        if (task == null) return NotFound();
        return Ok(task);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);
        if (!result) return NotFound();
        return Ok();
    }
}