using Microsoft.EntityFrameworkCore;

namespace DarkestTodo.Models;

public class DarkestTodoDb : DbContext
{
  public DarkestTodoDb(DbContextOptions options) : base(options) { }
  public DbSet<Todo> Todos { get; set; } = null!;
  public DbSet<Bonus> Bonuses { get; set; } = null!;
  public DbSet<User> Users { get; set; } = null!;

}