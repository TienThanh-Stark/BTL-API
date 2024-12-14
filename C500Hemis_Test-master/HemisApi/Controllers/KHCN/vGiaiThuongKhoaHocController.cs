using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.KHCN
{
    [Route("api/khcn/[controller]")]
    [ApiController]
    public class vGiaiThuongKhoaHocController : ControllerBase
    {
        private readonly HemisContext _context;

        public vGiaiThuongKhoaHocController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/VGiaiThuongKhoaHoc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VGiaiThuongKhoaHoc>>> GetVGiaiThuongKhoaHocs()
        {
            return await _context.VGiaiThuongKhoaHocs.ToListAsync();
        }

        // GET: api/VGiaiThuongKhoaHoc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VGiaiThuongKhoaHoc>> GetVGiaiThuongKhoaHoc(int id)
        {
            var VGiaiThuongKhoaHoc = await _context.VGiaiThuongKhoaHocs.FindAsync(id);

            if (VGiaiThuongKhoaHoc == null)
            {
                return NotFound();
            }

            return VGiaiThuongKhoaHoc;
        }

    }
}
