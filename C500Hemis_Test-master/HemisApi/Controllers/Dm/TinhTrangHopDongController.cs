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
    public class TinhTrangHopDongController : ControllerBase
    {
        private readonly HemisContext _context;

        public TinhTrangHopDongController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmTinhTrangHopDong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmTinhTrangHopDong>>> GetDmTinhTrangHopDongs()
        {
            return await _context.DmTinhTrangHopDongs.ToListAsync();
        }

        // GET: api/DmTinhTrangHopDong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmTinhTrangHopDong>> GetDmTinhTrangHopDong(int id)
        {
            var dmTinhTrangHopDong = await _context.DmTinhTrangHopDongs.FindAsync(id);

            if (dmTinhTrangHopDong == null)
            {
                return NotFound();
            }

            return dmTinhTrangHopDong;
        }

        private bool DmTinhTrangHopDongExists(int id)
        {
            return _context.DmTinhTrangHopDongs.Any(e => e.IdTinhTrangHopDong == id);
        }
    }
}
