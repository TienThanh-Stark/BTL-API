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
    public class PhanLoaiDoiNguNguoiHocController : ControllerBase
    {
        private readonly HemisContext _context;

        public PhanLoaiDoiNguNguoiHocController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmPhanLoaiDoiNguNguoiHoc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmPhanLoaiDoiNguNguoiHoc>>> GetDmPhanLoaiDoiNguNguoiHocs()
        {
            return await _context.DmPhanLoaiDoiNguNguoiHocs.ToListAsync();
        }

        // GET: api/DmPhanLoaiDoiNguNguoiHoc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmPhanLoaiDoiNguNguoiHoc>> GetDmPhanLoaiDoiNguNguoiHoc(int id)
        {
            var dmPhanLoaiDoiNguNguoiHoc = await _context.DmPhanLoaiDoiNguNguoiHocs.FindAsync(id);

            if (dmPhanLoaiDoiNguNguoiHoc == null)
            {
                return NotFound();
            }

            return dmPhanLoaiDoiNguNguoiHoc;
        }

        private bool DmPhanLoaiDoiNguNguoiHocExists(int id)
        {
            return _context.DmPhanLoaiDoiNguNguoiHocs.Any(e => e.IdPhanLoaiDoiNguNguoiHoc == id);
        }
    }
}
