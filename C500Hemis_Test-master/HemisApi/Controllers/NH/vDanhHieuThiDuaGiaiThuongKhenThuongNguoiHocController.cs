using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.NH
{
    [Route("api/nh/[controller]")]
    [ApiController]
    public class vDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocController : ControllerBase
    {
        private readonly HemisContext _context;

        public vDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/VDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc>>> GetVDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs()
        {
            return await _context.VDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs.ToListAsync();
        }

        // GET: api/VDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc>> GetVDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc(int id)
        {
            var VDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc = await _context.VDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs.FindAsync(id);

            if (VDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc == null)
            {
                return NotFound();
            }

            return VDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc;
        }

 
    }
}
