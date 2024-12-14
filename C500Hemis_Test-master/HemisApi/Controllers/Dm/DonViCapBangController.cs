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
    public class DonViCapBangController : ControllerBase
    {
        private readonly HemisContext _context;

        public DonViCapBangController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmDonViCapBang
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmDonViCapBang>>> GetDmDonViCapBangs()
        {
            return await _context.DmDonViCapBangs.ToListAsync();
        }

        // GET: api/DmDonViCapBang/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmDonViCapBang>> GetDmDonViCapBang(int id)
        {
            var dmDonViCapBang = await _context.DmDonViCapBangs.FindAsync(id);

            if (dmDonViCapBang == null)
            {
                return NotFound();
            }

            return dmDonViCapBang;
        }

        private bool DmDonViCapBangExists(int id)
        {
            return _context.DmDonViCapBangs.Any(e => e.IdDonViCapBang == id);
        }
    }
}
