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
    public class QuanHamController : ControllerBase
    {
        private readonly HemisContext _context;

        public QuanHamController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmQuanHam
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmQuanHam>>> GetDmQuanHams()
        {
            return await _context.DmQuanHams.ToListAsync();
        }

        // GET: api/DmQuanHam/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmQuanHam>> GetDmQuanHam(int id)
        {
            var dmQuanHam = await _context.DmQuanHams.FindAsync(id);

            if (dmQuanHam == null)
            {
                return NotFound();
            }

            return dmQuanHam;
        }

        private bool DmQuanHamExists(int id)
        {
            return _context.DmQuanHams.Any(e => e.IdQuanHam == id);
        }
    }
}
