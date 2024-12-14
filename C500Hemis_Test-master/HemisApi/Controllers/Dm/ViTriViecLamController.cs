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
    public class ViTriViecLamController : ControllerBase
    {
        private readonly HemisContext _context;

        public ViTriViecLamController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmViTriViecLam
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmViTriViecLam>>> GetDmViTriViecLams()
        {
            return await _context.DmViTriViecLams.ToListAsync();
        }

        // GET: api/DmViTriViecLam/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmViTriViecLam>> GetDmViTriViecLam(int id)
        {
            var dmViTriViecLam = await _context.DmViTriViecLams.FindAsync(id);

            if (dmViTriViecLam == null)
            {
                return NotFound();
            }

            return dmViTriViecLam;
        }

        private bool DmViTriViecLamExists(int id)
        {
            return _context.DmViTriViecLams.Any(e => e.IdViTriViecLam == id);
        }
    }
}
