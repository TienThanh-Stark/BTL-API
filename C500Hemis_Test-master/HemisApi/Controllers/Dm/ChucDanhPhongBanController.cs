using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.Dm
{
    [Route("api/dm/[controller]")]
    [ApiController]
    public class ChucDanhPhongBanController : ControllerBase
    {
        private readonly HemisContext _context;

        public ChucDanhPhongBanController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmChucDanhPhongBan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmChucDanhPhongBan>>> GetDmChucDanhPhongBans()
        {
            return await _context.DmChucDanhPhongBans.ToListAsync();
        }

        // GET: api/DmChucDanhPhongBan/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmChucDanhPhongBan>> GetDmChucDanhPhongBan(int id)
        {
            var dmChucDanhPhongBan = await _context.DmChucDanhPhongBans.FindAsync(id);

            if (dmChucDanhPhongBan == null)
            {
                return NotFound();
            }

            return dmChucDanhPhongBan;
        }

        private bool DmChucDanhPhongBanExists(int id)
        {
            return _context.DmChucDanhPhongBans.Any(e => e.IdChucDanhPhongBan == id);
        }
    }
}
