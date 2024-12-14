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
    public class HinhThucDoanhNghiepKhcnController : ControllerBase
    {
        private readonly HemisContext _context;

        public HinhThucDoanhNghiepKhcnController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmHinhThucDoanhNghiepKhcn
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmHinhThucDoanhNghiepKhcn>>> GetDmHinhThucDoanhNghiepKhcns()
        {
            return await _context.DmHinhThucDoanhNghiepKhcns.ToListAsync();
        }

        // GET: api/DmHinhThucDoanhNghiepKhcn/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmHinhThucDoanhNghiepKhcn>> GetDmHinhThucDoanhNghiepKhcn(int id)
        {
            var dmHinhThucDoanhNghiepKhcn = await _context.DmHinhThucDoanhNghiepKhcns.FindAsync(id);

            if (dmHinhThucDoanhNghiepKhcn == null)
            {
                return NotFound();
            }

            return dmHinhThucDoanhNghiepKhcn;
        }

        private bool DmHinhThucDoanhNghiepKhcnExists(int id)
        {
            return _context.DmHinhThucDoanhNghiepKhcns.Any(e => e.IdHinhThucDoanhNghiepKhcn == id);
        }
    }
}
