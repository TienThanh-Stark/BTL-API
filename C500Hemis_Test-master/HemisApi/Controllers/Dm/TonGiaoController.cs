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
    public class TonGiaoController : ControllerBase
    {
        private readonly HemisContext _context;

        public TonGiaoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmTonGiao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmTonGiao>>> GetDmTonGiaos()
        {
            return await _context.DmTonGiaos.ToListAsync();
        }

        // GET: api/DmTonGiao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmTonGiao>> GetDmTonGiao(int id)
        {
            var dmTonGiao = await _context.DmTonGiaos.FindAsync(id);

            if (dmTonGiao == null)
            {
                return NotFound();
            }

            return dmTonGiao;
        }

        private bool DmTonGiaoExists(int id)
        {
            return _context.DmTonGiaos.Any(e => e.IdTonGiao == id);
        }
    }
}
