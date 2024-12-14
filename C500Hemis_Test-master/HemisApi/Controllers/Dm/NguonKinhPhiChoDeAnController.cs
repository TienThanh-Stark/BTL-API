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
    public class NguonKinhPhiChoDeAnController : ControllerBase
    {
        private readonly HemisContext _context;

        public NguonKinhPhiChoDeAnController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmNguonKinhPhiChoDeAn
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmNguonKinhPhiChoDeAn>>> GetDmNguonKinhPhiChoDeAns()
        {
            return await _context.DmNguonKinhPhiChoDeAns.ToListAsync();
        }

        // GET: api/DmNguonKinhPhiChoDeAn/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmNguonKinhPhiChoDeAn>> GetDmNguonKinhPhiChoDeAn(int id)
        {
            var dmNguonKinhPhiChoDeAn = await _context.DmNguonKinhPhiChoDeAns.FindAsync(id);

            if (dmNguonKinhPhiChoDeAn == null)
            {
                return NotFound();
            }

            return dmNguonKinhPhiChoDeAn;
        }

        private bool DmNguonKinhPhiChoDeAnExists(int id)
        {
            return _context.DmNguonKinhPhiChoDeAns.Any(e => e.IdNguonKinhPhiChoDeAn == id);
        }
    }
}
