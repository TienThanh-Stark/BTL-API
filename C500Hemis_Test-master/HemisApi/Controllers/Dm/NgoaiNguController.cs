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
    public class NgoaiNguController : ControllerBase
    {
        private readonly HemisContext _context;

        public NgoaiNguController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmNgoaiNgu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmNgoaiNgu>>> GetDmNgoaiNgus()
        {
            return await _context.DmNgoaiNgus.ToListAsync();
        }

        // GET: api/DmNgoaiNgu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmNgoaiNgu>> GetDmNgoaiNgu(int id)
        {
            var dmNgoaiNgu = await _context.DmNgoaiNgus.FindAsync(id);

            if (dmNgoaiNgu == null)
            {
                return NotFound();
            }

            return dmNgoaiNgu;
        }

        private bool DmNgoaiNguExists(int id)
        {
            return _context.DmNgoaiNgus.Any(e => e.IdNgoaiNgu == id);
        }
    }
}
