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
    public class DanhHieuVinhDuGiaiThuongController : ControllerBase
    {
        private readonly HemisContext _context;

        public DanhHieuVinhDuGiaiThuongController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmDanhHieuVinhDuGiaiThuong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmDanhHieuVinhDuGiaiThuong>>> GetDmDanhHieuVinhDuGiaiThuongs()
        {
            return await _context.DmDanhHieuVinhDuGiaiThuongs.ToListAsync();
        }

        // GET: api/DmDanhHieuVinhDuGiaiThuong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmDanhHieuVinhDuGiaiThuong>> GetDmDanhHieuVinhDuGiaiThuong(int id)
        {
            var dmDanhHieuVinhDuGiaiThuong = await _context.DmDanhHieuVinhDuGiaiThuongs.FindAsync(id);

            if (dmDanhHieuVinhDuGiaiThuong == null)
            {
                return NotFound();
            }

            return dmDanhHieuVinhDuGiaiThuong;
        }

        private bool DmDanhHieuVinhDuGiaiThuongExists(int id)
        {
            return _context.DmDanhHieuVinhDuGiaiThuongs.Any(e => e.IdDanhHieuVinhDuGiaiThuong == id);
        }
    }
}
