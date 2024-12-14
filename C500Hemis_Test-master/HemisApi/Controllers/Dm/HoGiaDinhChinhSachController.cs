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
    public class HoGiaDinhChinhSachController : ControllerBase
    {
        private readonly HemisContext _context;

        public HoGiaDinhChinhSachController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmHoGiaDinhChinhSach
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmHoGiaDinhChinhSach>>> GetDmHoGiaDinhChinhSachs()
        {
            return await _context.DmHoGiaDinhChinhSaches.ToListAsync();
        }

        // GET: api/DmHoGiaDinhChinhSach/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmHoGiaDinhChinhSach>> GetDmHoGiaDinhChinhSach(int id)
        {
            var dmHoGiaDinhChinhSach = await _context.DmHoGiaDinhChinhSaches.FindAsync(id);

            if (dmHoGiaDinhChinhSach == null)
            {
                return NotFound();
            }

            return dmHoGiaDinhChinhSach;
        }

        private bool DmHoGiaDinhChinhSachExists(int id)
        {
            return _context.DmHoGiaDinhChinhSaches.Any(e => e.IdHoGiaDinhChinhSach == id);
        }
    }
}
