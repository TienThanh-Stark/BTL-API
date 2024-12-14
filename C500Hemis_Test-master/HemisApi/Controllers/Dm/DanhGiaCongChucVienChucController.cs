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
    public class DanhGiaCongChucVienChucController : ControllerBase
    {
        private readonly HemisContext _context;

        public DanhGiaCongChucVienChucController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmDanhGiaCongChucVienChuc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmDanhGiaCongChucVienChuc>>> GetDmDanhGiaCongChucVienChucs()
        {
            return await _context.DmDanhGiaCongChucVienChucs.ToListAsync();
        }

        // GET: api/DmDanhGiaCongChucVienChuc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmDanhGiaCongChucVienChuc>> GetDmDanhGiaCongChucVienChuc(int id)
        {
            var dmDanhGiaCongChucVienChuc = await _context.DmDanhGiaCongChucVienChucs.FindAsync(id);

            if (dmDanhGiaCongChucVienChuc == null)
            {
                return NotFound();
            }

            return dmDanhGiaCongChucVienChuc;
        }

        private bool DmDanhGiaCongChucVienChucExists(int id)
        {
            return _context.DmDanhGiaCongChucVienChucs.Any(e => e.IdDanhGiaCongChucVienChuc == id);
        }
    }
}
