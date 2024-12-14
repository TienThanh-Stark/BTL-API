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
    public class ChuSoHuuController : ControllerBase
    {
        private readonly HemisContext _context;

        public ChuSoHuuController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmChuSoHuu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmChuSoHuu>>> GetDmChuSoHuus()
        {
            return await _context.DmChuSoHuus.ToListAsync();
        }

        // GET: api/DmChuSoHuu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmChuSoHuu>> GetDmChuSoHuu(int id)
        {
            var dmChuSoHuu = await _context.DmChuSoHuus.FindAsync(id);

            if (dmChuSoHuu == null)
            {
                return NotFound();
            }

            return dmChuSoHuu;
        }

        private bool DmChuSoHuuExists(int id)
        {
            return _context.DmChuSoHuus.Any(e => e.IdChuSoHuu == id);
        }
    }
}
