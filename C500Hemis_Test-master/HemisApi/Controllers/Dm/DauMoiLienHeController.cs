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
    public class DauMoiLienHeController : ControllerBase
    {
        private readonly HemisContext _context;

        public DauMoiLienHeController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmDauMoiLienHe
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmDauMoiLienHe>>> GetDmDauMoiLienHes()
        {
            return await _context.DmDauMoiLienHes.ToListAsync();
        }

        // GET: api/DmDauMoiLienHe/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmDauMoiLienHe>> GetDmDauMoiLienHe(int id)
        {
            var dmDauMoiLienHe = await _context.DmDauMoiLienHes.FindAsync(id);

            if (dmDauMoiLienHe == null)
            {
                return NotFound();
            }

            return dmDauMoiLienHe;
        }

        private bool DmDauMoiLienHeExists(int id)
        {
            return _context.DmDauMoiLienHes.Any(e => e.IdDauMoiLienHe == id);
        }
    }
}
