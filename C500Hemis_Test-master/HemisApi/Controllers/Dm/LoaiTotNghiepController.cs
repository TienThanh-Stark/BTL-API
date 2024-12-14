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
    public class LoaiTotNghiepController : ControllerBase
    {
        private readonly HemisContext _context;

        public LoaiTotNghiepController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmLoaiTotNghiep
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmLoaiTotNghiep>>> GetDmLoaiTotNghieps()
        {
            return await _context.DmLoaiTotNghieps.ToListAsync();
        }

        // GET: api/DmLoaiTotNghiep/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmLoaiTotNghiep>> GetDmLoaiTotNghiep(int id)
        {
            var dmLoaiTotNghiep = await _context.DmLoaiTotNghieps.FindAsync(id);

            if (dmLoaiTotNghiep == null)
            {
                return NotFound();
            }

            return dmLoaiTotNghiep;
        }

        private bool DmLoaiTotNghiepExists(int id)
        {
            return _context.DmLoaiTotNghieps.Any(e => e.IdLoaiTotNghiep == id);
        }
    }
}
