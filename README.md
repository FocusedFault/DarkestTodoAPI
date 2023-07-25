# Darkest Todo API

dotnet run
http://localhost:{PORT}/swagger for swagger docs
dotnet build
dotnet ef migrations add InitialCreate
dotnet ef migrations add SomeDescriptiveName (when making changes)
dotnet ef database update

## HTTP Repl

httprepl https://localhost:{PORT} or connect https://localhost:{PORT}
ls to list available endpoints
cd {ENDPOINT} goes to the endpoint
get makes a get request at the endpoint
exit to end the session

## Things to add

- Add authentication (login/signup)

Whenever updating a todo, update the user as well and return the user object.
// Bonus Types: 0 is xp, 1 is crit, 2 is stress
// Rarities: 0 is uncommon, 1 is rare, 2 is legendary
this list should be on the frontend
new Bonus
{
Id = 0,
Name = "Unwavering Standard",
Description = "Boost XP gain by 2%",
Rarity = 0,
Type = 0,
Value = 0.02f
},
new Bonus
{
Id = 0,
Name = "Thrilling Tablet",
Description = "Boost XP gain by 5%",
Rarity = 1,
Type = 0,
Value = 0.05f
},
new Bonus
{
Id = 0,
Name = "Misstep",
Description = "Boost XP gain by 10%",
Rarity = 2,
Type = 0,
Value = 0.1f
},
new Bonus
{
Id = 0,
Name = "Armory Key",
Description = "Increase Critical Chance by 2%",
Rarity = 0,
Type = 1,
Value = 0.02f
},
new Bonus
{
Id = 0,
Name = "Prodding Pendant",
Description = "Increase Critical Chance by 5%",
Rarity = 1,
Type = 1,
Value = 0.05f
},
new Bonus
{
Id = 0,
Name = "Wounding Words",
Description = "Increase Critical Chance by 10%",
Rarity = 2,
Type = 1,
Value = 0.1f
},
new Bonus
{
Id = 0,
Name = "Blistering Bugle",
Description = "Reduce Stress Chance by 2%",
Rarity = 0,
Type = 2,
Value = 0.02f
},
new Bonus
{
Id = 0,
Name = "Sparkleball",
Description = "Reduce Stress Chance by 5%",
Rarity = 1,
Type = 2,
Value = 0.05f
},
new Bonus
{
Id = 0,
Name = "Sickening Silence",
Description = "Reduce Stress Chance by 10%",
Rarity = 2,
Type = 2,
Value = 0.1f
}
