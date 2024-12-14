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
    public class LoaiThamGiaController : ControllerBase
    {
        private readonly HemisContext _context;

        public LoaiThamGiaController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmLoaiThamGia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmLoaiThamGia>>> GetDmLoaiThamGias()
        {
            return await _context.DmLoaiThamGias.ToListAsync();
        }

        // GET: api/DmLoaiThamGia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmLoaiThamGia>> GetDmLoaiThamGia(int id)
        {
            var dmLoaiThamGia = await _context.DmLoaiThamGias.FindAsync(id);

            if (dmLoaiThamGia == null)
            {
                return NotFound();
            }

            return dmLoaiThamGia;
        }

        private bool DmLoaiThamGiaExists(int id)
        {
            return _context.DmLoaiThamGias.Any(e => e.IdLoaiThamGia == id);
        }
    }
}
