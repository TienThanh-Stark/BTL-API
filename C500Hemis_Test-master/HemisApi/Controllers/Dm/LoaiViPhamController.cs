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
    public class LoaiViPhamController : ControllerBase
    {
        private readonly HemisContext _context;

        public LoaiViPhamController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmLoaiViPham
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmLoaiViPham>>> GetDmLoaiViPhams()
        {
            return await _context.DmLoaiViPhams.ToListAsync();
        }

        // GET: api/DmLoaiViPham/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmLoaiViPham>> GetDmLoaiViPham(int id)
        {
            var dmLoaiViPham = await _context.DmLoaiViPhams.FindAsync(id);

            if (dmLoaiViPham == null)
            {
                return NotFound();
            }

            return dmLoaiViPham;
        }

        private bool DmLoaiViPhamExists(int id)
        {
            return _context.DmLoaiViPhams.Any(e => e.IdLoaiViPham == id);
        }
    }
}
