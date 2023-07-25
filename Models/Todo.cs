namespace DarkestTodo.Models;

public class Todo
{
  public int Id { get; set; }
  public string? Description { get; set; }
  public int Xp { get; set; } = 100;
  public bool IsComplete { get; set; }
  public int UserId { get; set; }
}