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
    public class NguonKinhPhiChoLuuHocSinhController : ControllerBase
    {
        private readonly HemisContext _context;

        public NguonKinhPhiChoLuuHocSinhController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmNguonKinhPhiChoLuuHocSinh
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmNguonKinhPhiChoLuuHocSinh>>> GetDmNguonKinhPhiChoLuuHocSinhs()
        {
            return await _context.DmNguonKinhPhiChoLuuHocSinhs.ToListAsync();
        }

        // GET: api/DmNguonKinhPhiChoLuuHocSinh/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmNguonKinhPhiChoLuuHocSinh>> GetDmNguonKinhPhiChoLuuHocSinh(int id)
        {
            var dmNguonKinhPhiChoLuuHocSinh = await _context.DmNguonKinhPhiChoLuuHocSinhs.FindAsync(id);

            if (dmNguonKinhPhiChoLuuHocSinh == null)
            {
                return NotFound();
            }

            return dmNguonKinhPhiChoLuuHocSinh;
        }

        private bool DmNguonKinhPhiChoLuuHocSinhExists(int id)
        {
            return _context.DmNguonKinhPhiChoLuuHocSinhs.Any(e => e.IdNguonKinhPhiChoLuuHocSinh == id);
        }
    }
}
