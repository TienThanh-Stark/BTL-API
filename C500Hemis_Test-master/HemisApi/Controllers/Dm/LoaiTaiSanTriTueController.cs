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
    public class LoaiTaiSanTriTueController : ControllerBase
    {
        private readonly HemisContext _context;

        public LoaiTaiSanTriTueController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmLoaiTaiSanTriTue
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmLoaiTaiSanTriTue>>> GetDmLoaiTaiSanTriTues()
        {
            return await _context.DmLoaiTaiSanTriTues.ToListAsync();
        }

        // GET: api/DmLoaiTaiSanTriTue/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmLoaiTaiSanTriTue>> GetDmLoaiTaiSanTriTue(int id)
        {
            var dmLoaiTaiSanTriTue = await _context.DmLoaiTaiSanTriTues.FindAsync(id);

            if (dmLoaiTaiSanTriTue == null)
            {
                return NotFound();
            }

            return dmLoaiTaiSanTriTue;
        }

        private bool DmLoaiTaiSanTriTueExists(int id)
        {
            return _context.DmLoaiTaiSanTriTues.Any(e => e.IdLoaiTaiSanTriTue == id);
        }
    }
}
