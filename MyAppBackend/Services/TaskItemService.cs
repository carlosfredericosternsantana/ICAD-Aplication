using Microsoft.EntityFrameworkCore;
using MyAppBackend.Data;
using MyAppBackend.Models;
namespace MyAppBackend.Services;
public class TaskItemService
{
    private readonly AppDbContext _context;
    public TaskItemService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<TaskItem>> GetAllAsync()
    {
        return await _context.Tasks.Include(t => t.User).ToListAsync();
    }
    public async Task<TaskItem?> GetByIdAsync(int id)
    {
        return await _context.Tasks.Include(t => t.User).FirstOrDefaultAsync(t => t.Id == id);
    }
    public async Task<TaskItem> CreateAsync(TaskItem task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return task;
    }
    public async Task<TaskItem?> UpdateAsync(int id, TaskItem updated)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null) return null;
        task.Title = updated.Title;
        task.Description = updated.Description;
        task.DueDate = updated.DueDate;
        task.Difficulty = updated.Difficulty;
        task.IsCompleted = updated.IsCompleted;
        task.UserId = updated.UserId;
        await _context.SaveChangesAsync();
        return task;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null) return false;
        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        return true;
    }
}