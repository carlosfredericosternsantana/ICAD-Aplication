namespace MyAppBackend.DTOs;
public class TaskItemDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public string Difficulty { get; set; }
    public bool IsCompleted { get; set; }
    public int UserId { get; set; }
    public string UserName { get; set; } // útil para mostrar o responsável no frontend
}