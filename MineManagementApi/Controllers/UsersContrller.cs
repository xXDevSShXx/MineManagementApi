using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MineManagementApi.Models;

namespace MineManagementApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersContrller : ControllerBase
    {
        MineManagementApiDbContext db;

        public UsersContrller(MineManagementApiDbContext dbContext)
        {
            db = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Login(int personalId)
        {
            var user = await db.Users.FirstOrDefaultAsync(e => e.PersonalID.Equals(personalId));
            if (user == null)
            {
                return BadRequest("User Not Found");
            }
            return Ok(user);
        }
    }
}
