using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSalonWebApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BSalonWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminBoardAPIController : ControllerBase
    {
        private readonly BSalonDbContext _context;
        public AdminBoardAPIController(BSalonDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get([FromHeader] int id)
        {
            var user = _context.Records.FirstOrDefault(x => x.ID == id);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteRecord([FromHeader]int id)
        {
            var record = await _context.Records.FirstOrDefaultAsync(r => r.ID == id);
            if (record == null)
            {
                return BadRequest();
            }

            _context.Records.Remove(record);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
