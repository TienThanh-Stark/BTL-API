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
    public class HinhThucTuyenDungController : ControllerBase
    {
        private readonly HemisContext _context;

        public HinhThucTuyenDungController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmHinhThucTuyenDung
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmHinhThucTuyenDung>>> GetDmHinhThucTuyenDungs()
        {
            return await _context.DmHinhThucTuyenDungs.ToListAsync();
        }

        // GET: api/DmHinhThucTuyenDung/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmHinhThucTuyenDung>> GetDmHinhThucTuyenDung(int id)
        {
            var dmHinhThucTuyenDung = await _context.DmHinhThucTuyenDungs.FindAsync(id);

            if (dmHinhThucTuyenDung == null)
            {
                return NotFound();
            }

            return dmHinhThucTuyenDung;
        }

        private bool DmHinhThucTuyenDungExists(int id)
        {
            return _context.DmHinhThucTuyenDungs.Any(e => e.IdHinhThucTuyenDung == id);
        }
    }
}
