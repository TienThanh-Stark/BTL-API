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
    public class DoiTuongUuTienController : ControllerBase
    {
        private readonly HemisContext _context;

        public DoiTuongUuTienController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmDoiTuongUuTien
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmDoiTuongUuTien>>> GetDmDoiTuongUuTiens()
        {
            return await _context.DmDoiTuongUuTiens.ToListAsync();
        }

        // GET: api/DmDoiTuongUuTien/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmDoiTuongUuTien>> GetDmDoiTuongUuTien(int id)
        {
            var dmDoiTuongUuTien = await _context.DmDoiTuongUuTiens.FindAsync(id);

            if (dmDoiTuongUuTien == null)
            {
                return NotFound();
            }

            return dmDoiTuongUuTien;
        }

        private bool DmDoiTuongUuTienExists(int id)
        {
            return _context.DmDoiTuongUuTiens.Any(e => e.IdDoiTuongUuTien == id);
        }
    }
}
