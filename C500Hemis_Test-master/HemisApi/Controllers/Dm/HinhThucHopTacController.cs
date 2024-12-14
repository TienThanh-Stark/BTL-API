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
    public class HinhThucHopTacController : ControllerBase
    {
        private readonly HemisContext _context;

        public HinhThucHopTacController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmHinhThucHopTac
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmHinhThucHopTac>>> GetDmHinhThucHopTacs()
        {
            return await _context.DmHinhThucHopTacs.ToListAsync();
        }

        // GET: api/DmHinhThucHopTac/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmHinhThucHopTac>> GetDmHinhThucHopTac(int id)
        {
            var dmHinhThucHopTac = await _context.DmHinhThucHopTacs.FindAsync(id);

            if (dmHinhThucHopTac == null)
            {
                return NotFound();
            }

            return dmHinhThucHopTac;
        }

        private bool DmHinhThucHopTacExists(int id)
        {
            return _context.DmHinhThucHopTacs.Any(e => e.IdHinhThucHopTac == id);
        }
    }
}
