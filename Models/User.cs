namespace DarkestTodo.Models;

public class User
{
  public int Id { get; set; }
  public string? Auth { get; set; }
  public int Stress { get; set; } = 0;
  public int Xp { get; set; } = 0;
  public int Level { get; set; } = 0;
  public int LevelUp { get; set; } = 100;
  public ICollection<Todo> Todos { get; } = new List<Todo>();
  public ICollection<Bonus> Bonuses { get; } = new List<Bonus>();
}