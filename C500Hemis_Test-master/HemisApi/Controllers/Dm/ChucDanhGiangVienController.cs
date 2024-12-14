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
    public class ChucDanhGiangVienController : ControllerBase
    {
        private readonly HemisContext _context;

        public ChucDanhGiangVienController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmChucDanhGiangVien
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmChucDanhGiangVien>>> GetDmChucDanhGiangViens()
        {
            return await _context.DmChucDanhGiangViens.ToListAsync();
        }

        // GET: api/DmChucDanhGiangVien/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmChucDanhGiangVien>> GetDmChucDanhGiangVien(int id)
        {
            var dmChucDanhGiangVien = await _context.DmChucDanhGiangViens.FindAsync(id);

            if (dmChucDanhGiangVien == null)
            {
                return NotFound();
            }

            return dmChucDanhGiangVien;
        }

        private bool DmChucDanhGiangVienExists(int id)
        {
            return _context.DmChucDanhGiangViens.Any(e => e.IdChucDanhGiangVien == id);
        }
    }
}
