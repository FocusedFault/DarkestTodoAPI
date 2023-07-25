using DarkestTodo.Models;

namespace DarkestTodo.Services;

public class DarkestService
{
  public static List<bool> TodoComplete(User user, Todo todo)
  {
    float xpMultiplier = 1f;
    float critChance = 0.01f;
    float stressChance = 0.25f;
    bool hadMeltdown = false;
    bool hadLevelUp = false;

    if (user.Bonuses != null && user.Bonuses.Count() > 0)
    {
      foreach (Bonus bonus in user.Bonuses)
      {
        switch (bonus.Type)
        {
          case 0:
            xpMultiplier += bonus.Value;
            break;
          case 1:
            critChance += bonus.Value;
            break;
          case 2:
            stressChance -= bonus.Value;
            break;
        }
      }
    }
    int xp = (int)Math.Round(todo.Xp * xpMultiplier);
    Random random = new Random();
    double randCrit = random.NextDouble();
    if (randCrit < critChance)
      xp *= 2;
    double randStress = random.NextDouble();
    if (randStress < stressChance)
      HandleStress(user, hadMeltdown);
    int sum = user.Xp + xp;
    if (sum >= user.LevelUp)
    {
      LevelUp(user, sum - user.LevelUp);
      hadLevelUp = true;
    }
    else
      user.Xp += xp;

    List<bool> response = new()
    {
      hadMeltdown,
      hadLevelUp
    };

    return response;
  }

  public static void LevelUp(User user, int xp)
  {
    user.Xp = xp;
    user.Level += 1;
    int xpNextLevel = 100 * (user.Level + 1) * (user.Level + 1);
    user.LevelUp = xpNextLevel;
  }

  public static void HandleStress(User user, bool meltdown)
  {
    if (user.Stress + 1 >= 5)
    {
      meltdown = true;
      user.Stress = 0;
    }
    else user.Stress += 1;
  }
}