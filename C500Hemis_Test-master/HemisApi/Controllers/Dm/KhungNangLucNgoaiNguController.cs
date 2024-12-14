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
    public class KhungNangLucNgoaiNguController : ControllerBase
    {
        private readonly HemisContext _context;

        public KhungNangLucNgoaiNguController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmKhungNangLucNgoaiNgu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmKhungNangLucNgoaiNgu>>> GetDmKhungNangLucNgoaiNgus()
        {
            return await _context.DmKhungNangLucNgoaiNgus.ToListAsync();
        }

        // GET: api/DmKhungNangLucNgoaiNgu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmKhungNangLucNgoaiNgu>> GetDmKhungNangLucNgoaiNgu(int id)
        {
            var dmKhungNangLucNgoaiNgu = await _context.DmKhungNangLucNgoaiNgus.FindAsync(id);

            if (dmKhungNangLucNgoaiNgu == null)
            {
                return NotFound();
            }

            return dmKhungNangLucNgoaiNgu;
        }

        private bool DmKhungNangLucNgoaiNguExists(int id)
        {
            return _context.DmKhungNangLucNgoaiNgus.Any(e => e.IdKhungNangLucNgoaiNgu == id);
        }
    }
}
