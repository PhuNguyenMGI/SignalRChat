namespace SignalRChat.Models;

[EnableCors("Policy")]
public class GroupsServices
{
    public static async Task<IResult> GetAllGroups(ApplicationDbContext db)
    {
        return TypedResults.Ok(await db.Groups.ToListAsync());
    }
    public static async Task<IResult> GetGroupById(int id, ApplicationDbContext db)
    {
        return TypedResults.Ok(await db.Groups.FindAsync(id)
            is Groups group ? Results.Ok(group) : Results.NotFound());
    }

    public static async Task<IResult> InsertGroup(Groups group, ApplicationDbContext db)
    {
        db.Groups.Add(group);
        await db.SaveChangesAsync();

        return TypedResults.Created($"/groups/{group.id}", group);
    }

    public static async Task<IResult> UpdateGroup(int id, Groups inputGroup, ApplicationDbContext db)
    {
        var group = await db.Groups.FindAsync(id);

        if (group is null) return Results.NotFound();

        group.groupname = inputGroup.groupname;

        await db.SaveChangesAsync();

        return TypedResults.NoContent();
    }

    public static async Task<IResult> DeleteGroup(int id, ApplicationDbContext db)
    {
        if (await db.Groups.FindAsync(id) is Groups group)
        {
            db.Groups.Remove(group);
            await db.SaveChangesAsync();
            return TypedResults.Ok(group);
        }

        return TypedResults.NotFound();
    }
}