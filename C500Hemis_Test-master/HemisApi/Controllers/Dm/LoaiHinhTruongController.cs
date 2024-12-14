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
    public class LoaiHinhTruongController : ControllerBase
    {
        private readonly HemisContext _context;

        public LoaiHinhTruongController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmLoaiHinhTruong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmLoaiHinhTruong>>> GetDmLoaiHinhTruongs()
        {
            return await _context.DmLoaiHinhTruongs.ToListAsync();
        }

        // GET: api/DmLoaiHinhTruong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmLoaiHinhTruong>> GetDmLoaiHinhTruong(int id)
        {
            var dmLoaiHinhTruong = await _context.DmLoaiHinhTruongs.FindAsync(id);

            if (dmLoaiHinhTruong == null)
            {
                return NotFound();
            }

            return dmLoaiHinhTruong;
        }

        private bool DmLoaiHinhTruongExists(int id)
        {
            return _context.DmLoaiHinhTruongs.Any(e => e.IdLoaiHinhTruong == id);
        }
    }
}
