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
    public class LoaiPhongBanController : ControllerBase
    {
        private readonly HemisContext _context;

        public LoaiPhongBanController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmLoaiPhongBan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmLoaiPhongBan>>> GetDmLoaiPhongBans()
        {
            return await _context.DmLoaiPhongBans.ToListAsync();
        }

        // GET: api/DmLoaiPhongBan/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmLoaiPhongBan>> GetDmLoaiPhongBan(int id)
        {
            var dmLoaiPhongBan = await _context.DmLoaiPhongBans.FindAsync(id);

            if (dmLoaiPhongBan == null)
            {
                return NotFound();
            }

            return dmLoaiPhongBan;
        }

        private bool DmLoaiPhongBanExists(int id)
        {
            return _context.DmLoaiPhongBans.Any(e => e.IdLoaiPhongBan == id);
        }
    }
}
