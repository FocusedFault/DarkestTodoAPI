using DarkestTodo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DarkestBonus.Controllers;

[ApiController]
[Route("[controller]")]
public class BonusController : ControllerBase
{
  private readonly DarkestTodoDb _db;

  public BonusController(DarkestTodoDb db)
  {
    _db = db;
  }

  // POST action
  [HttpPost]
  public async Task<IResult> Create(Bonus Bonus)
  {
    await _db.Bonuses.AddAsync(Bonus);
    await _db.SaveChangesAsync();
    return Results.Created($"/bonus/{Bonus.Id}", Bonus);
  }
}