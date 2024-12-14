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
    public class HinhThucThanhLapController : ControllerBase
    {
        private readonly HemisContext _context;

        public HinhThucThanhLapController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmHinhThucThanhLap
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmHinhThucThanhLap>>> GetDmHinhThucThanhLaps()
        {
            return await _context.DmHinhThucThanhLaps.ToListAsync();
        }

        // GET: api/DmHinhThucThanhLap/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmHinhThucThanhLap>> GetDmHinhThucThanhLap(int id)
        {
            var dmHinhThucThanhLap = await _context.DmHinhThucThanhLaps.FindAsync(id);

            if (dmHinhThucThanhLap == null)
            {
                return NotFound();
            }

            return dmHinhThucThanhLap;
        }

        private bool DmHinhThucThanhLapExists(int id)
        {
            return _context.DmHinhThucThanhLaps.Any(e => e.IdHinhThucThanhLap == id);
        }
    }
}
