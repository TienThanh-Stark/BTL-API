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
    public class LoaiDeTaiController : ControllerBase
    {
        private readonly HemisContext _context;

        public LoaiDeTaiController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmLoaiDeTai
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmLoaiDeTai>>> GetDmLoaiDeTais()
        {
            return await _context.DmLoaiDeTais.ToListAsync();
        }

        // GET: api/DmLoaiDeTai/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmLoaiDeTai>> GetDmLoaiDeTai(int id)
        {
            var dmLoaiDeTai = await _context.DmLoaiDeTais.FindAsync(id);

            if (dmLoaiDeTai == null)
            {
                return NotFound();
            }

            return dmLoaiDeTai;
        }

        private bool DmLoaiDeTaiExists(int id)
        {
            return _context.DmLoaiDeTais.Any(e => e.IdLoaiDeTai == id);
        }
    }
}
