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
    public class LoaiPhongHocController : ControllerBase
    {
        private readonly HemisContext _context;

        public LoaiPhongHocController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmLoaiPhongHoc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmLoaiPhongHoc>>> GetDmLoaiPhongHocs()
        {
            return await _context.DmLoaiPhongHocs.ToListAsync();
        }

        // GET: api/DmLoaiPhongHoc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmLoaiPhongHoc>> GetDmLoaiPhongHoc(int id)
        {
            var dmLoaiPhongHoc = await _context.DmLoaiPhongHocs.FindAsync(id);

            if (dmLoaiPhongHoc == null)
            {
                return NotFound();
            }

            return dmLoaiPhongHoc;
        }

        private bool DmLoaiPhongHocExists(int id)
        {
            return _context.DmLoaiPhongHocs.Any(e => e.IdLoaiPhongHoc == id);
        }
    }
}
