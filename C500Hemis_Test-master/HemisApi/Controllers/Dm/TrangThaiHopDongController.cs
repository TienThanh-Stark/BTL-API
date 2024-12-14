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
    public class TrangThaiHopDongController: ControllerBase
    {
        private readonly HemisContext _context;

        public TrangThaiHopDongController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmTrangThaiHopDong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmTrangThaiHopDong>>> GetDmTrangThaiHopDongs()
        {
            return await _context.DmTrangThaiHopDongs.ToListAsync();
        }

        // GET: api/DmTrangThaiHopDong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmTrangThaiHopDong>> GetDmTrangThaiHopDong(int id)
        {
            var dmTrangThaiHopDong = await _context.DmTrangThaiHopDongs.FindAsync(id);

            if (dmTrangThaiHopDong == null)
            {
                return NotFound();
            }

            return dmTrangThaiHopDong;
        }

        private bool DmTrangThaiHopDongExists(int id)
        {
            return _context.DmTrangThaiHopDongs.Any(e => e.IdTrangThaiHopDong == id);
        }
    }
}
