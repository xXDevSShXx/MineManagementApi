using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MineManagementApi.Models;

namespace MineManagementApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly MineManagementApiDbContext db;
        public LocationsController(MineManagementApiDbContext dbContext)
        {
            db = dbContext;
        }
        [HttpPost]
        public async Task<IActionResult> Update(LocationVM vm)
        {
            try
            {
                if ((await db.Users.FindAsync(vm.UserId)) == null)
                    return BadRequest("User Not Found");
                var entity = Location.Create(vm, DateTime.Now);
                await db.Locations.AddAsync(entity);
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, ex.Source);
            }
        }

        [HttpGet()]
        public async Task<IActionResult> List()
        {
            return Ok(await db.Locations.ToListAsync());
        }
    }
}
