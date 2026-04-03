namespace MyAppBackend.DTOs;

public class CreateTaskItemDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public string Difficulty { get; set; }
    public int UserId { get; set; }
    public bool IsCompleted { get; set; }
}