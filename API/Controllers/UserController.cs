using API.Entities;
using API.Data; // Add this if your DbContext is in a Data folder
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;


namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : BaseApiController
{
    private readonly DataContext _context;

    public UserController(DataContext context)
    {
        _context = context;
    }
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var user = await _context.Users.ToListAsync();
        return user;
    }
    [Authorize]
    [HttpGet("{id:int}")]
    public ActionResult<AppUser> GetUser(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null) return NotFound();
        return user;
    }
}
