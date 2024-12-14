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
    public class TrangThaiCanBoController : ControllerBase
    {
        private readonly HemisContext _context;

        public TrangThaiCanBoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmTrangThaiCanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmTrangThaiCanBo>>> GetDmTrangThaiCanBos()
        {
            return await _context.DmTrangThaiCanBos.ToListAsync();
        }

        // GET: api/DmTrangThaiCanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmTrangThaiCanBo>> GetDmTrangThaiCanBo(int id)
        {
            var dmTrangThaiCanBo = await _context.DmTrangThaiCanBos.FindAsync(id);

            if (dmTrangThaiCanBo == null)
            {
                return NotFound();
            }

            return dmTrangThaiCanBo;
        }

        private bool DmTrangThaiCanBoExists(int id)
        {
            return _context.DmTrangThaiCanBos.Any(e => e.IdTrangThaiCanBo == id);
        }
    }
}
