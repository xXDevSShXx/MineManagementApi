using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MineManagementApi.Models;

namespace MineManagementApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController()]
    public class UsersController : ControllerBase
    {
        MineManagementApiDbContext db;

        public UsersController(MineManagementApiDbContext dbContext)
        {
            db = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]int personalId)
        {
            var user = await db.Users.FirstAsync(e => e.PersonalID.Equals(personalId));
            if (user == null)
            {
                return BadRequest("User Not Found");
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserVM vm)
        {
            User user = new User
            {
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                PersonalID = vm.PersonalID
            };
            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var users = await db.Users.ToListAsync();
            return Ok(users);
        }
    }
}
