using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.TS
{
    [Route("api/ts/[controller]")]
    [ApiController]
    public class vChiTieuTuyenSinhTheoNganhController : ControllerBase
    {
        private readonly HemisContext _context;

        public vChiTieuTuyenSinhTheoNganhController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/VChiTieuTuyenSinhTheoNganh
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VChiTieuTuyenSinhTheoNganh>>> GetVChiTieuTuyenSinhTheoNganhs()
        {
            return await _context.VChiTieuTuyenSinhTheoNganhs.ToListAsync();
        }

        // GET: api/VChiTieuTuyenSinhTheoNganh/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VChiTieuTuyenSinhTheoNganh>> GetVChiTieuTuyenSinhTheoNganh(int id)
        {
            var VChiTieuTuyenSinhTheoNganh = await _context.VChiTieuTuyenSinhTheoNganhs.FindAsync(id);

            if (VChiTieuTuyenSinhTheoNganh == null)
            {
                return NotFound();
            }

            return VChiTieuTuyenSinhTheoNganh;
        }

   
    }
}
