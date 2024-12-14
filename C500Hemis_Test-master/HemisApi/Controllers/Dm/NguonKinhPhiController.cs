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
    public class NguonKinhPhiController : ControllerBase
    {
        private readonly HemisContext _context;

        public NguonKinhPhiController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmguonKinhPhi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmNguonKinhPhi>>> GetDmguonKinhPhis()
        {
            return await _context.DmNguonKinhPhis.ToListAsync();
        }

        // GET: api/DmguonKinhPhi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmNguonKinhPhi>> GetDmguonKinhPhi(int id)
        {
            var dmguonKinhPhi = await _context.DmNguonKinhPhis.FindAsync(id);

            if (dmguonKinhPhi == null)
            {
                return NotFound();
            }

            return dmguonKinhPhi;
        }

        private bool DmguonKinhPhiExists(int id)
        {
            return _context.DmNguonKinhPhis.Any(e => e.IdNguonKinhPhi == id);
        }
    }
}
