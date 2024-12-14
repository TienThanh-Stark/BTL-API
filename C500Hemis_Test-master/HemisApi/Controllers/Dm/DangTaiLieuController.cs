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
    public class DangTaiLieuController : ControllerBase
    {
        private readonly HemisContext _context;

        public DangTaiLieuController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmDangTaiLieu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmDangTaiLieu>>> GetDmDangTaiLieus()
        {
            return await _context.DmDangTaiLieus.ToListAsync();
        }

        // GET: api/DmDangTaiLieu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmDangTaiLieu>> GetDmDangTaiLieu(int id)
        {
            var dmDangTaiLieu = await _context.DmDangTaiLieus.FindAsync(id);

            if (dmDangTaiLieu == null)
            {
                return NotFound();
            }

            return dmDangTaiLieu;
        }

        private bool DmDangTaiLieuExists(int id)
        {
            return _context.DmDangTaiLieus.Any(e => e.IdDangTaiLieu == id);
        }
    }
}
