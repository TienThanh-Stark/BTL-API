using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.NH
{
    [Route("api/nh/[controller]")]
    [ApiController]
    public class vHocVienController : ControllerBase
    {
        private readonly HemisContext _context;

        public vHocVienController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/VHocVien
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VHocVien>>> GetVHocViens()
        {
            return await _context.VHocViens.ToListAsync();
        }

        // GET: api/VHocVien/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VHocVien>> GetVHocVien(int id)
        {
            var VHocVien = await _context.VHocViens.FindAsync(id);

            if (VHocVien == null)
            {
                return NotFound();
            }

            return VHocVien;
        }

    }
}
