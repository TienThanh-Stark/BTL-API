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
    public class XaController : ControllerBase
    {
        private readonly HemisContext _context;

        public XaController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmXa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmXa>>> GetDmXas()
        {
            return await _context.DmXas.ToListAsync();
        }

        // GET: api/DmXa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmXa>> GetDmXa(int id)
        {
            var dmXa = await _context.DmXas.FindAsync(id);

            if (dmXa == null)
            {
                return NotFound();
            }

            return dmXa;
        }

        private bool DmXaExists(int id)
        {
            return _context.DmXas.Any(e => e.IdXa == id);
        }
    }
}
