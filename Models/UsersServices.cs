namespace SignalRChat.Models;

[EnableCors("Policy")]
public class UsersServices
{
    public static async Task<IResult> LoginRequest(string username, string password, ApplicationDbContext db)
    {
        return TypedResults.Ok(await db.Users.Where(t => t.name == username && t.password == password).ToListAsync());
    }
    public static async Task<IResult> GetUsersByGroup(int group, ApplicationDbContext db)
    {
        return TypedResults.Ok(await db.Users.Where(t => t.Groups.id == group).ToListAsync());
    }
    public static async Task<IResult> GetUserById(int id, ApplicationDbContext db)
    {
        return TypedResults.Ok(await db.Users.FindAsync(id)
            is Users user ? Results.Ok(user) : Results.NotFound());
    }

    public static async Task<IResult> InsertUser(Users user, ApplicationDbContext db)
    {
        db.Users.Add(user);
        await db.SaveChangesAsync();

        return TypedResults.Created($"/users/{user.id}", user);
    }

    public static async Task<IResult> UpdateUser(int id, Users inputUser, ApplicationDbContext db)
    {
        var user = await db.Users.FindAsync(id);

        if (user is null) return Results.NotFound();

        user.name = inputUser.name;
        user.password = inputUser.password;

        await db.SaveChangesAsync();

        return TypedResults.NoContent();
    }

    public static async Task<IResult> DeleteUser(int id, ApplicationDbContext db)
    {
        if (await db.Users.FindAsync(id) is Users user)
        {
            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return TypedResults.Ok(user);
        }

        return TypedResults.NotFound();
    }
}