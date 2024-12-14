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
    public class HinhThucSoHuuController : ControllerBase
    {
        private readonly HemisContext _context;

        public HinhThucSoHuuController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmHinhThucSoHuu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmHinhThucSoHuu>>> GetDmHinhThucSoHuus()
        {
            return await _context.DmHinhThucSoHuus.ToListAsync();
        }

        // GET: api/DmHinhThucSoHuu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmHinhThucSoHuu>> GetDmHinhThucSoHuu(int id)
        {
            var dmHinhThucSoHuu = await _context.DmHinhThucSoHuus.FindAsync(id);

            if (dmHinhThucSoHuu == null)
            {
                return NotFound();
            }

            return dmHinhThucSoHuu;
        }

        private bool DmHinhThucSoHuuExists(int id)
        {
            return _context.DmHinhThucSoHuus.Any(e => e.IdHinhThucSoHuu == id);
        }
    }
}
