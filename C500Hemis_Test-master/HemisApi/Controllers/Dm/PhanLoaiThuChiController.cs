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
    public class PhanLoaiThuChiController : ControllerBase
    {
        private readonly HemisContext _context;

        public PhanLoaiThuChiController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmPhanLoaiThuChi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmPhanLoaiThuChi>>> GetDmPhanLoaiThuChis()
        {
            return await _context.DmPhanLoaiThuChis.ToListAsync();
        }

        // GET: api/DmPhanLoaiThuChi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmPhanLoaiThuChi>> GetDmPhanLoaiThuChi(int id)
        {
            var dmPhanLoaiThuChi = await _context.DmPhanLoaiThuChis.FindAsync(id);

            if (dmPhanLoaiThuChi == null)
            {
                return NotFound();
            }

            return dmPhanLoaiThuChi;
        }

        private bool DmPhanLoaiThuChiExists(int id)
        {
            return _context.DmPhanLoaiThuChis.Any(e => e.IdPhanLoaiThuChi == id);
        }
    }
}
