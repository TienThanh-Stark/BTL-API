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
    public class LoaiQuyetDinhController : ControllerBase
    {
        private readonly HemisContext _context;

        public LoaiQuyetDinhController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmLoaiQuyetDinh
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmLoaiQuyetDinh>>> GetDmLoaiQuyetDinhs()
        {
            return await _context.DmLoaiQuyetDinhs.ToListAsync();
        }

        // GET: api/DmLoaiQuyetDinh/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmLoaiQuyetDinh>> GetDmLoaiQuyetDinh(int id)
        {
            var dmLoaiQuyetDinh = await _context.DmLoaiQuyetDinhs.FindAsync(id);

            if (dmLoaiQuyetDinh == null)
            {
                return NotFound();
            }

            return dmLoaiQuyetDinh;
        }

        private bool DmLoaiQuyetDinhExists(int id)
        {
            return _context.DmLoaiQuyetDinhs.Any(e => e.IdLoaiQuyetDinh == id);
        }
    }
}
