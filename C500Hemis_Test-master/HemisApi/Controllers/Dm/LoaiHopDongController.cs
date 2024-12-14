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
    public class LoaiHopDongController : ControllerBase
    {
        private readonly HemisContext _context;

        public LoaiHopDongController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmLoaiHopDong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmLoaiHopDong>>> GetDmLoaiHopDongs()
        {
            return await _context.DmLoaiHopDongs.ToListAsync();
        }

        // GET: api/DmLoaiHopDong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmLoaiHopDong>> GetDmLoaiHopDong(int id)
        {
            var dmLoaiHopDong = await _context.DmLoaiHopDongs.FindAsync(id);

            if (dmLoaiHopDong == null)
            {
                return NotFound();
            }

            return dmLoaiHopDong;
        }

        private bool DmLoaiHopDongExists(int id)
        {
            return _context.DmLoaiHopDongs.Any(e => e.IdLoaiHopDong == id);
        }
    }
}
