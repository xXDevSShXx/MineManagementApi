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
        MineManagementApiDbContext _db;

        public UsersContrller(MineManagementApiDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> Login(int personalId)
        {
            var user = await _db.Users.FirstOrDefaultAsync(e => e.PersonalID.Equals(personalId));
            if (user == null)
            {
                return BadRequest("Requested Entity Was Not Found");
            }
            return Ok(user);
        }
    }
}
