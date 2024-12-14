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
    public class TrangThaiThucHienController : ControllerBase
    {
        private readonly HemisContext _context;

        public TrangThaiThucHienController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmTrangThaiThucHien
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmTrangThaiThucHien>>> GetDmTrangThaiThucHiens()
        {
            return await _context.DmTrangThaiThucHiens.ToListAsync();
        }

        // GET: api/DmTrangThaiThucHien/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmTrangThaiThucHien>> GetDmTrangThaiThucHien(int id)
        {
            var dmTrangThaiThucHien = await _context.DmTrangThaiThucHiens.FindAsync(id);

            if (dmTrangThaiThucHien == null)
            {
                return NotFound();
            }

            return dmTrangThaiThucHien;
        }

        private bool DmTrangThaiThucHienExists(int id)
        {
            return _context.DmTrangThaiThucHiens.Any(e => e.IdTrangThaiThucHien == id);
        }
    }
}
