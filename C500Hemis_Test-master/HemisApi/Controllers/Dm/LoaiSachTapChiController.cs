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
    public class LoaiSachTapChiController : ControllerBase
    {
        private readonly HemisContext _context;

        public LoaiSachTapChiController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmLoaiSachTapChi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmLoaiSachTapChi>>> GetDmLoaiSachTapChis()
        {
            return await _context.DmLoaiSachTapChis.ToListAsync();
        }

        // GET: api/DmLoaiSachTapChi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmLoaiSachTapChi>> GetDmLoaiSachTapChi(int id)
        {
            var dmLoaiSachTapChi = await _context.DmLoaiSachTapChis.FindAsync(id);

            if (dmLoaiSachTapChi == null)
            {
                return NotFound();
            }

            return dmLoaiSachTapChi;
        }

        private bool DmLoaiSachTapChiExists(int id)
        {
            return _context.DmLoaiSachTapChis.Any(e => e.IdLoaiSachTapChi == id);
        }
    }
}
