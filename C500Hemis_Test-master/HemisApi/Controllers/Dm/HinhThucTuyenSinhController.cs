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
    public class HinhThucTuyenSinhController : ControllerBase
    {
        private readonly HemisContext _context;

        public HinhThucTuyenSinhController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmHinhThucTuyenSinh
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmHinhThucTuyenSinh>>> GetDmHinhThucTuyenSinhs()
        {
            return await _context.DmHinhThucTuyenSinhs.ToListAsync();
        }

        // GET: api/DmHinhThucTuyenSinh/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmHinhThucTuyenSinh>> GetDmHinhThucTuyenSinh(int id)
        {
            var dmHinhThucTuyenSinh = await _context.DmHinhThucTuyenSinhs.FindAsync(id);

            if (dmHinhThucTuyenSinh == null)
            {
                return NotFound();
            }

            return dmHinhThucTuyenSinh;
        }

        private bool DmHinhThucTuyenSinhExists(int id)
        {
            return _context.DmHinhThucTuyenSinhs.Any(e => e.IdHinhThucTuyenSinh == id);
        }
    }
}
