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
    public class vDanhSachVanBangChungChiController : ControllerBase
    {
        private readonly HemisContext _context;

        public vDanhSachVanBangChungChiController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/VDanhSachVanBangChungChi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VDanhSachVanBangChungChi>>> GetVDanhSachVanBangChungChis()
        {
            return await _context.VDanhSachVanBangChungChis.ToListAsync();
        }

        // GET: api/VDanhSachVanBangChungChi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VDanhSachVanBangChungChi>> GetVDanhSachVanBangChungChi(int id)
        {
            var VDanhSachVanBangChungChi = await _context.VDanhSachVanBangChungChis.FindAsync(id);

            if (VDanhSachVanBangChungChi == null)
            {
                return NotFound();
            }

            return VDanhSachVanBangChungChi;
        }


    }
}
