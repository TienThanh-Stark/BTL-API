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
    public class vKyLuatNguoiHocController : ControllerBase
    {
        private readonly HemisContext _context;

        public vKyLuatNguoiHocController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/VKyLuatNguoiHoc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VKyLuatNguoiHoc>>> GetVKyLuatNguoiHocs()
        {
            return await _context.VKyLuatNguoiHocs.ToListAsync();
        }

        // GET: api/VKyLuatNguoiHoc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VKyLuatNguoiHoc>> GetVKyLuatNguoiHoc(int id)
        {
            var VKyLuatNguoiHoc = await _context.VKyLuatNguoiHocs.FindAsync(id);

            if (VKyLuatNguoiHoc == null)
            {
                return NotFound();
            }

            return VKyLuatNguoiHoc;
        }

    }
}
