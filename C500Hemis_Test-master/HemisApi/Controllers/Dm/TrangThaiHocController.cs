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
    public class TrangThaiHocController : ControllerBase
    {
        private readonly HemisContext _context;

        public TrangThaiHocController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmTrangThaiHoc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmTrangThaiHoc>>> GetDmTrangThaiHocs()
        {
            return await _context.DmTrangThaiHocs.ToListAsync();
        }

        // GET: api/DmTrangThaiHoc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmTrangThaiHoc>> GetDmTrangThaiHoc(int id)
        {
            var dmTrangThaiHoc = await _context.DmTrangThaiHocs.FindAsync(id);

            if (dmTrangThaiHoc == null)
            {
                return NotFound();
            }

            return dmTrangThaiHoc;
        }

        private bool DmTrangThaiHocExists(int id)
        {
            return _context.DmTrangThaiHocs.Any(e => e.IdTrangThaiHoc == id);
        }
    }
}
