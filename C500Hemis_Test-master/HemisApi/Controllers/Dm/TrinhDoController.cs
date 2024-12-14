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
    public class TrinhDoController : ControllerBase
    {
        private readonly HemisContext _context;

        public TrinhDoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmTrinhDo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmTrinhDo>>> GetDmTrinhDos()
        {
            return await _context.DmTrinhDos.ToListAsync();
        }

        // GET: api/DmTrinhDo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmTrinhDo>> GetDmTrinhDo(int id)
        {
            var dmTrinhDo = await _context.DmTrinhDos.FindAsync(id);

            if (dmTrinhDo == null)
            {
                return NotFound();
            }

            return dmTrinhDo;
        }

        private bool DmTrinhDoExists(int id)
        {
            return _context.DmTrinhDos.Any(e => e.IdTrinhDo == id);
        }
    }
}
