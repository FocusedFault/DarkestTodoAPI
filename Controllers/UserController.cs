using DarkestTodo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DarkestTodo.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
  private readonly DarkestTodoDb _db;

  public UserController(DarkestTodoDb db)
  {
    _db = db;
    _db.Users
        .Include(user => user.Todos)
        .ToList();
    _db.Users
        .Include(user => user.Bonuses)
        .ToList();
  }

  // GET by Id action
  [HttpGet("{id}")]
  public async Task<ActionResult<User>> Get(int id)
  {
    User? user = await _db.Users.FindAsync(id);

    if (user == null)
      return NotFound();

    return user;
  }

  // POST action
  [HttpPost]
  public async Task<IResult> Create(User user)
  {
    await _db.Users.AddAsync(user);
    await _db.SaveChangesAsync();
    return Results.Created($"/user/{user.Id}", user);
  }

}