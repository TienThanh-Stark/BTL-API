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
    public class LoaiGiaiThuongKhcnController : ControllerBase
    {
        private readonly HemisContext _context;

        public LoaiGiaiThuongKhcnController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmLoaiGiaiThuongKhcn
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmLoaiGiaiThuongKhcn>>> GetDmLoaiGiaiThuongKhcns()
        {
            return await _context.DmLoaiGiaiThuongKhcns.ToListAsync();
        }

        // GET: api/DmLoaiGiaiThuongKhcn/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmLoaiGiaiThuongKhcn>> GetDmLoaiGiaiThuongKhcn(int id)
        {
            var dmLoaiGiaiThuongKhcn = await _context.DmLoaiGiaiThuongKhcns.FindAsync(id);

            if (dmLoaiGiaiThuongKhcn == null)
            {
                return NotFound();
            }

            return dmLoaiGiaiThuongKhcn;
        }

        private bool DmLoaiGiaiThuongKhcnExists(int id)
        {
            return _context.DmLoaiGiaiThuongKhcns.Any(e => e.IdLoaiGiaiThuongKhcn == id);
        }
    }
}
