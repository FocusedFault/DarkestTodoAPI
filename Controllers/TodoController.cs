using DarkestTodo.Models;
using Microsoft.AspNetCore.Mvc;
using DarkestTodo.Services;
using Microsoft.EntityFrameworkCore;

namespace DarkestTodo.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{
  private readonly DarkestTodoDb _db;

  public TodoController(DarkestTodoDb db)
  {
    _db = db;
    _db.Users
        .Include(user => user.Todos)
        .ToList();
    _db.Users
        .Include(user => user.Bonuses)
        .ToList();
  }

  // POST action
  [HttpPost]
  public async Task<IResult> Create(Todo todo)
  {
    await _db.Todos.AddAsync(todo);
    await _db.SaveChangesAsync();
    return Results.Created($"/todo/{todo.Id}", todo);
  }

  // PUT action
  [HttpPut("{id}")]
  public async Task<IResult> Update(int id, Todo updatedTodo)
  {
    Todo? todo = await _db.Todos.FindAsync(id);
    if (todo is null) return Results.NotFound();
    todo.IsComplete = updatedTodo.IsComplete;
    User? user = await _db.Users.FindAsync(todo.UserId);
    if (user is null) return Results.NotFound();
    // Service call to process the user's xp/stress
    List<bool> serviceRes = DarkestService.TodoComplete(user, todo);
    // Delete all bonuses if user had a meltdown
    if (serviceRes[0])
    {
      foreach (Bonus bonus in user.Bonuses)
        _db.Bonuses.Remove(bonus);
    }
    await _db.SaveChangesAsync();
    // Get the fresh user (in case bonuses were deleted)
    User? updatedUser = await _db.Users.FindAsync(todo.UserId);
    if (updatedUser is null) return Results.NotFound();
    // Return data for the frontend
    object response = new
    {
      HadMeltdown = serviceRes[0],
      HadLevelUp = serviceRes[1],
      User = updatedUser,
    };
    return Results.Json(response);
  }

  // DELETE action
  /* delete todo after being marked complete
  [HttpDelete("{id}")]
  public async Task<IResult> Delete(int id)
  {
    Todo? todo = await _db.Todos.FindAsync(id);
    if (todo is null)
    {
      return Results.NotFound();
    }
    _db.Todos.Remove(todo);
    await _db.SaveChangesAsync();
    return Results.Ok();
  }
  */
}