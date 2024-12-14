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
    public class HinhThucDaoTaoTheoChuyenNguController : ControllerBase
    {
        private readonly HemisContext _context;

        public HinhThucDaoTaoTheoChuyenNguController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmHinhThucDaoTaoTheoChuyenNgu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmHinhThucDaoTaoTheoChuyenNgu>>> GetDmHinhThucDaoTaoTheoChuyenNgus()
        {
            return await _context.DmHinhThucDaoTaoTheoChuyenNgus.ToListAsync();
        }

        // GET: api/DmHinhThucDaoTaoTheoChuyenNgu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmHinhThucDaoTaoTheoChuyenNgu>> GetDmHinhThucDaoTaoTheoChuyenNgu(int id)
        {
            var dmHinhThucDaoTaoTheoChuyenNgu = await _context.DmHinhThucDaoTaoTheoChuyenNgus.FindAsync(id);

            if (dmHinhThucDaoTaoTheoChuyenNgu == null)
            {
                return NotFound();
            }

            return dmHinhThucDaoTaoTheoChuyenNgu;
        }

        private bool DmHinhThucDaoTaoTheoChuyenNguExists(int id)
        {
            return _context.DmHinhThucDaoTaoTheoChuyenNgus.Any(e => e.IdHinhThucDaoTaoTheoChuyenNgu == id);
        }
    }
}
