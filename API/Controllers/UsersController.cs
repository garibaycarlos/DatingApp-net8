using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize]
public class UsersController(DataContext context) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await context.Users.ToListAsync();

        return users;
    }

    [HttpGet("{id:int}")] // api/users/1
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        var getUser = await context.Users.FindAsync(id);

        if (getUser == null)
        {
            return NotFound();
        }

        return getUser;
    }
}
